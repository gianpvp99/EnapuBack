using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class User
    {
        public User()
        {
            this.commonTables = new CommonTables();
        }

        public User(string password, string user)
        {
            this.password = password;
            this.nameUser = user;
        }

        public int id { get; set; }
        public int idRol { get; set; }
        public string RolDescription { get; set; }
        public string idTerminalPortuario { get; set; }
        public string terminalPortuarioDescription { get; set; }
        public string lastName { get; set; }
        public string lastMotherName { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string department { get; set; }
        public string province { get; set; }    
        public string disctrict { get; set; }
        public string address { get; set; }
        public string numberPhone { get; set; }
        public string email { get; set; }
        public string nameUser { get; set; }
        public string password { get; set; }
        public string messagge { get; set; }
        public CommonTables commonTables { get; set; }
    }
}
