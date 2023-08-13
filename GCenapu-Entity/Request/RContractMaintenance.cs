using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public class RContractMaintenanceAdd
    {
        public int id {get;set;}
        public string idTerminalPortuario {get;set;}
        public string descriptionLong {get;set;}
        public string descriptionShort {get;set;}
        public string idClient {get;set;}
        public int idTypeContract {get;set;}
        public DateTime dateContract {get;set;}
        public DateTime dateStart {get;set;}
        public DateTime dateEnd {get;set;}
        public string DirectionContract {get;set;}
        public int idUsuario {get;set;}
        public string user {get;set;}
        public int option { get; set; }
        public List<RContractDetailMaintenance> detail { get; set; }
        public List<RResponsibleMaintenance> responsible { get; set; }
       
    }
    public class RContractMaintenance
    {
        public int id { get; set; }
        public string idTerminalPortuario { get; set; }
        public string descriptionLong { get; set; }
        public string descriptionShort { get; set; }
        public string idClient { get; set; }
        public int idTypeContract { get; set; }
        public DateTime dateContract { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string DirectionContract { get; set; }
        public int idUsuario { get; set; }
        public string user { get; set; }
        public int option { get; set; }

    }
}
