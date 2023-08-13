using GCenapu_Contracts;
using GCenapu_Data;
using GCenapu_Entity;
using GCenapu_Entity.EResponse;
using GCenapu_Entity.Request;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GCenapu_Business
{
    public class Buser : IUser
    {
        readonly IConfiguration _configuration;

        public Buser(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public async Task<List<User>> List()
        {
            return await new DUser(_configuration).List();
            
        }

        public async Task<User> Login(login login)
        {
            return await new DUser(_configuration).Login(login);
        }

        public async Task<int> Maintenance(RUserMaintenance user)
        {
            try
            {
                if(user.option==0)
                {
                    DUser dUser = new DUser(_configuration);
                    UserValidate vUserUser = new UserValidate();
                    UserValidate vUserEmail = new UserValidate();
                    vUserUser = await dUser.ValidateUserEmail(user.nameUser, user.email, 0);
                    vUserEmail = await dUser.ValidateUserEmail(user.nameUser, user.email, 1);
                    if (vUserUser != null || vUserEmail != null)
                    {
                        if (vUserUser.user != null)
                        {
                            return 2;//usuario ya existe

                        }else 
                        {
                            if (vUserEmail.email != null)
                            {
                                return 3; //email ya existe
                            }
                            else
                            {
                                return await new DUser(_configuration).Maintenance(user);
                            }
                               
                        } 
                    }
                    else
                    {
                        return await new DUser(_configuration).Maintenance(user);
                    }
                }
                /*MODIFICAR EL USUARIO
                //else if (user.option == 1)
                //{
                //    DUser dUser = new DUser(_configuration);
                //    UserValidate vUserEmail = new UserValidate();
                //    vUserEmail = await dUser.ValidateUserEmail(user.nameUser, user.email, 1);
                //    if (vUserEmail.email != null)
                //    {
                //        return 3;
                //    }
                //    else
                //    {
                //        return await new DUser(_configuration).Maintenance(user);
                //    }

                //}*/

                else
                {
                    return await new DUser(_configuration).Maintenance(user);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
           
        }

        public async Task<List<User>> Search(string text)
        {
            return await new DUser(_configuration).Search(text);
        }

        public async Task<User> Search(int id)
        {
            return await new DUser(_configuration).Search(id);
        }

        public async Task<List<User>> SearchActivesTerminal(string terminal)
        {
            return await new DUser(_configuration).SearchActivesTerminal(terminal);
        }

        public async Task<User> SearchUser(string user)
        {
            return await new DUser(_configuration).SearchUser(user);
        }
    }
}
