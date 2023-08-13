using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface Iperiod
    {
        Task<int> Maintenance(RPeriodMaintenance typeContract);
        Task<List<Period>> Search(string text);
        Task<List<Period>> List();
        Task<List<Period>> ListActive();
    }
}
