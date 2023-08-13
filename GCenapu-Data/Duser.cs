using GCenapu_Contracts;
using GCenapu_Entity;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCenapu_Entity.common;
using GCenapu_Entity.Request;
using System.Xml.Linq;
using GCenapu_Entity.EResponse;
using static System.Net.Mime.MediaTypeNames;

namespace GCenapu_Data
{
    public class DUser : IUser
    {
        readonly IConfiguration _configuration;

        public DUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<User>> List()
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<User> list = new List<User>();
                    using (SqlCommand cmd = new SqlCommand("sp_user_list", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                           
                            while (dr.Read())
                            {
                                list.Add(new User()
                                {
                                    id=dr.GetInt32("id"),
                                    idRol=dr.GetInt32("idRol"),
                                    RolDescription = dr.GetString("rolDescription"),
                                    terminalPortuarioDescription = dr.GetString("terminalDescription"),
                                    idTerminalPortuario=dr.GetString("idTerminalPortuario"),
                                    lastName = dr.GetString("lastName"),
                                    lastMotherName = dr.GetString("lastNameMother"),
                                    name = dr.GetString("name"),
                                    department = dr.GetString("department"),
                                    province = dr.GetString("province"),
                                    disctrict = dr.GetString("district"),
                                    address = dr.GetString("address"),
                                    numberPhone = dr.GetString("numberPhone"),
                                    email = dr.GetString("email"),
                                    nameUser = dr.GetString("nameUser"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state"),
                                    }
                                });
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<User> Login(login login)
        {
            
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    User list = new User();
                    using (SqlCommand cmd = new SqlCommand("sp_user_login", cn))
                    {   
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nameUser", login.user);
                        cmd.Parameters.AddWithValue("@password", login.password);

                        cn.Open();
                        using (SqlDataReader dr=cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                list.messagge=dr.GetString("request");
                            }
                        }
                    }


                    if (list.messagge== "Acceso al sistema")
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_user_search_user", cn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user", login.user);
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                if (dr.Read())
                                {
                                    list.id = dr.GetInt32("id");
                                    list.idRol = dr.GetInt32("rolId");
                                    list.RolDescription = dr.GetString("RolDesc");
                                    list.idTerminalPortuario = dr.GetString("TerminalId");
                                    list.terminalPortuarioDescription = dr.GetString("terminalDescription");
                                    list.lastName = dr.GetString("lastName");
                                    list.lastMotherName = dr.GetString("lastNameMother");
                                    list.name = dr.GetString("name");
                                    list.department = dr.GetString("department");
                                    list.province = dr.GetString("province");
                                    list.disctrict = dr.GetString("district");
                                    list.address = dr.GetString("address");
                                    list.numberPhone = dr.GetString("numberPhone");
                                    list.email = dr.GetString("email");
                                    list.nameUser = dr.GetString("nameUser");
                                    list.commonTables.state = dr.GetBoolean("state");

                                }
                            }
                           
                        }
                      
                    }
                    cn.Close();
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
              
            }
        }

        public async Task<int> Maintenance(RUserMaintenance user)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_user_maintaining",cn)) 
                    { 
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", user.id);
                        cmd.Parameters.AddWithValue("@idRol", user.idRol);
                        cmd.Parameters.AddWithValue("@idTerminalPortuario", user.idTerminalPortuario);
                        cmd.Parameters.AddWithValue("@lastName", user.lastName);
                        cmd.Parameters.AddWithValue("@lastNameMother", user.lastNameMother);
                        cmd.Parameters.AddWithValue("@name", user.name);
                        cmd.Parameters.AddWithValue("@department", user.department);
                        cmd.Parameters.AddWithValue("@province", user.province);
                        cmd.Parameters.AddWithValue("@district", user.district);
                        cmd.Parameters.AddWithValue("@address", user.address);
                        cmd.Parameters.AddWithValue("@numberPhone", user.numberPhone);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@nameUser", user.nameUser);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@user", user.user);
                        cmd.Parameters.AddWithValue("@option", user.option);
                        int num;
                        cn.Open();
                        num=cmd.ExecuteNonQuery();
                        cn.Close();

                        return num;
                    }
                        
                }
                catch (Exception ex)
                {

                    throw new NotImplementedException();
                }
            }
        }

        public async Task<List<User>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<User> list = new List<User>();
                    using (SqlCommand cmd = new SqlCommand("sp_user_list", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text",text);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                list.Add(new User()
                                {
                                    id=dr.GetInt32("id"),
                                    RolDescription = dr.GetString("rolDescription"),
                                    terminalPortuarioDescription = dr.GetString("terminalDescription"),
                                    lastName = dr.GetString("lastName"),
                                    lastMotherName = dr.GetString("lastNameMother"),
                                    name = dr.GetString("name"),
                                    department = dr.GetString("department"),
                                    province = dr.GetString("province"),
                                    disctrict = dr.GetString("district"),
                                    address = dr.GetString("address"),
                                    numberPhone = dr.GetString("numberPhone"),
                                    email = dr.GetString("email"),
                                    nameUser = dr.GetString("nameUser"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state"),
                                    }
                                });
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<User> Search(int id)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    User list = new User();
                    using (SqlCommand cmd = new SqlCommand("sp_user_search_user_id", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            if (dr.Read())
                            {

                                list.id = dr.GetInt32("id");
                                list.RolDescription = dr.GetString("rolDescription");
                                list.terminalPortuarioDescription = dr.GetString("terminalDescription");
                                list.lastName = dr.GetString("lastName");
                                list.lastMotherName = dr.GetString("lastNameMother");
                                list.name = dr.GetString("name");
                                list.department = dr.GetString("department");
                                list.province = dr.GetString("province");
                                list.disctrict = dr.GetString("district");
                                list.address = dr.GetString("address");
                                list.numberPhone = dr.GetString("numberPhone");
                                list.email = dr.GetString("email");
                                list.nameUser = dr.GetString("nameUser");
                                list.commonTables.state = dr.GetBoolean("state");
                                
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<List<User>> SearchActivesTerminal(string terminal)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<User> list = new List<User>();
                    using (SqlCommand cmd = new SqlCommand("sp_user_list_responsibles_actives", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@terminal", terminal);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                list.Add(new User()
                                {
                                    id = dr.GetInt32("id"),
                                    RolDescription = dr.GetString("rolDescription"),
                                    terminalPortuarioDescription = dr.GetString("terminalDescription"),
                                    lastName = dr.GetString("lastName"),
                                    lastMotherName = dr.GetString("lastNameMother"),
                                    name = dr.GetString("name"),
                                    department = dr.GetString("department"),
                                    province = dr.GetString("province"),
                                    disctrict = dr.GetString("district"),
                                    address = dr.GetString("address"),
                                    numberPhone = dr.GetString("numberPhone"),
                                    email = dr.GetString("email"),
                                    nameUser = dr.GetString("nameUser"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state"),
                                    }
                                });
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<User> SearchUser(string user)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    User list = new User();
                    using (SqlCommand cmd = new SqlCommand("sp_user_search_user", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user", user);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            if (dr.Read())
                            {

                                list.id = dr.GetInt32("id");
                                list.idRol = dr.GetInt32("rolId");
                                list.RolDescription = dr.GetString("RolDesc");
                                list.idTerminalPortuario = dr.GetString("TerminalId");
                                list.terminalPortuarioDescription = dr.GetString("terminalDescription");
                                list.lastName = dr.GetString("lastName");
                                list.lastMotherName = dr.GetString("lastNameMother");
                                list.name = dr.GetString("name");
                                list.department = dr.GetString("department");
                                list.province = dr.GetString("province");
                                list.disctrict = dr.GetString("district");
                                list.address = dr.GetString("address");
                                list.numberPhone = dr.GetString("numberPhone");
                                list.email = dr.GetString("email");
                                list.nameUser = dr.GetString("nameUser");
                                list.commonTables.state = dr.GetBoolean("state");
                                
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public  async Task<UserValidate> ValidateUserEmail(string user, string email,int option)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    UserValidate list = new UserValidate();
                    using (SqlCommand cmd = new SqlCommand("sp_user_validate_user_email", cn))
                    {
                        cn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@option", option);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            if (dr.Read())
                            {

                                list.user = dr.GetString("nameUser");
                                list.email = dr.GetString("email"); 
                                
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
