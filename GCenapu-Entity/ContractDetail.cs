using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class ContractDetail
    {
        public ContractDetail() { 
            this.commonTables=new CommonTables();        
        }
        public int id {get;set;}
        public int idContract {get;set;}
        public string contractDescriptionLong { get;set;}
        public string contractDescriptionShort { get; set; }
        public string dateStart { get;set;}
        public string dateEnd { get;set;}
        public string idTarifa {get;set;}
        public string tarifaDescription { get; set; }
        public decimal tarifaAmount { get;set;}
        public int idPeriod {get;set;}
        public string periodDescription { get; set; }
        public int periodMonth { get;set;}
        public int idUnitMeasurement {get;set;}
        public string unitMeasurementDescription { get; set; }
        public int unit { get; set; }
        public string unitDescription { get;set;}
        public decimal periodoMeta {get;set;}
        public CommonTables commonTables { get;set;}

    }
}
