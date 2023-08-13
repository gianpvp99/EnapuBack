using GCenapu_Entity;
using GCenapu_Entity.EResponse;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IUser
    {
        Task<int> Maintenance(RUserMaintenance user);
        Task<List<User>> List();
        Task<List<User>> Search(string text);
        Task<User> Search(int id);
        Task<User> Login(login login);
        Task<User> SearchUser(string user);
        Task<List<User>> SearchActivesTerminal(string terminal);
        //Task<List<UserValidate>> ValidateUserEmail(string user, string email);
    }
}
