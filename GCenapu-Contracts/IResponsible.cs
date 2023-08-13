using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IResponsible
    {
        Task<int> Maintenance(RResponsibleMaintenance responsible);
        Task<List<Responsible>> Search(string text);
        Task<List<Responsible>> List();
        Task<List<Responsible>> List(int idContract);

    }
}
