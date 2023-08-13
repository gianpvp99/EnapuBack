using GCenapu_Entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity
{
    public class ContractPrograming
    {
        public ContractPrograming() { 
            this.commonTables =new CommonTables();
        } 
        public int id {get;set;}
        public int idDetailContract {get;set;}
        public string idTarifa {get;set;}
        public string descriptionTarifa { get;set;}
        public decimal month {get;set;}
        public decimal amounth { get;set;}
        public string dateStart {get;set;}
        public string dateEnd {get;set;}
        public decimal cantFacture {get;set;}
        public decimal cantOfMeta { get;set;}
        public CommonTables commonTables { get;set;}
    }
}
