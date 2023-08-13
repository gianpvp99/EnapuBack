using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IContract
    {
        Task<int> Maintenance(RContractMaintenance contract);
        Task<List<Contract>> Search(string text);
        Task<List<Contract>> List(string idPuerto);
        Task<int> Add(RContractMaintenanceAdd contract);
    }
}
