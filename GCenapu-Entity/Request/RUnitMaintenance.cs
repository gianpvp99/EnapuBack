using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public class RUnitMaintenance
    {
        public int id { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        public int option { get; set; }
    }
}
