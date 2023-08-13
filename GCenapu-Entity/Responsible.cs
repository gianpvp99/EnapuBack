using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class Responsible
    {
        public Responsible() {
            this.commonTables = new CommonTables();
        }
        public int id {get;set;}
        public int idContract {get;set;}
        public int idUser {get;set;}
        public string name { get;set;}
        public string email { get; set; }
        public string user { get;set;}
        public CommonTables commonTables { get;set;}

    }
}
