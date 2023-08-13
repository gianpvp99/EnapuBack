using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public  class RContractDetailMaintenance
    {
          public int id {get;set;}
          public int idContract {get;set;}
          public string idTarifa {get;set;}
          public int idPeriod {get;set;}
          public int idUnitMeasurement {get;set;}
          public decimal periodoMeta {get;set;}
          public string user {get;set;}
          public int option { get;set;}
    }
}
