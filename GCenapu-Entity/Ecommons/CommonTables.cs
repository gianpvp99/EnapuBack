using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.common
{
    public class CommonTables
    {
        public bool state { get; set; }
        public bool logDelete { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime dateUpdate { get; set; }
        public string user { get; set; }
        public int option { get; set; }
    }
}
