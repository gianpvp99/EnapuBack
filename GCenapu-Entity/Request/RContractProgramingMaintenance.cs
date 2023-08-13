using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public class RContractProgramingMaintenance
    {
        public int id { get; set; }
        public int idDetailContract { get; set; }
        public int idTarifa { get; set; }
        public string month { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public decimal cantFacture { get; set; }
        public string user { get; set; }
        public int option { get; set; }

    
    }
}
