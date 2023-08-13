using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class Role
    {
        public Role()
        {
            this.CommonTables = new CommonTables();
        }
        public int id { get; set; }
        public string description { get; set; }

        public CommonTables CommonTables { get; set; }
    }
}
