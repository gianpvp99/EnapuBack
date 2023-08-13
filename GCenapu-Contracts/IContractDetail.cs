using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IContractDetail
    {
        Task<int> Maintenance(RContractDetailMaintenance detailContract);
        Task<List<ContractDetail>> Search(string text);
        Task<List<ContractDetail>> List();
        Task<List<ContractDetail>> ListIdContract(int id);
    }
}
