using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public class RResponsibleMaintenance
    {
        public int id {get;set;}
        public int idContract {get;set;}
        public int idUser {get;set;}
        public string user {get;set;}
        public int option { get;set;}
    }
}
