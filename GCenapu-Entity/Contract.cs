using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    
    public class Contract
    {
        public Contract() { 
            this.commonTables=new CommonTables();
        }
        public int id {get;set;}
        public string idTerminalPortuario {get;set;}
        public string detailTerminalPortuario { get;set;}
        public string descriptionLong {get;set;}
        public string descriptionShort {get;set;}
        public string idClient {get;set;}
        public string cliente { get;set;}
        public int idTypeContract {get;set;}
        public string detailTypeContract { get;set;}
        public string dateContract {get;set;}
        public string dateStart {get;set;}
        public string dateEnd {get;set;}
        public string DirectionContract {get;set;}
        public int idUsuario {get;set;}
        public string user { get;set;}
        public int option { get; set; }
        public CommonTables commonTables { get; set; }

    }
}
