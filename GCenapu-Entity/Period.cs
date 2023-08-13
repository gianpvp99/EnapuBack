using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class Period
    {
        public Period()
        {
            this.CommonTables = new CommonTables();
        }

        public Period(int id,string description, string user, int option)
        {
            this.id = id;
            this.description = description;
            this.CommonTables.user= user;
            this.CommonTables.option= option;
        }
        public int id { get; set; }
        public string description { get; set; }
        public int month { get; set; }
        public CommonTables CommonTables { get; set; }
    }
}
