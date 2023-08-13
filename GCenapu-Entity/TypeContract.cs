using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class TypeContract
    {
        public TypeContract() {
            this.commonTables = new CommonTables();
        }

        public int id {  get; set; }
        public string typeContract { get; set; }
        public string description { get;set; }
        public CommonTables commonTables { get; set; }
       
    }
}
