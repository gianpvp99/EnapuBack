using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IContractPrograming
    {
        Task<int> Maintenance(RContractProgramingMaintenance contractPrograming);
        Task<List<ContractPrograming>> Search(string text);
        Task<List<ContractPrograming>> List();
        Task<List<ContractPrograming>> ListDestail(int id);
        Task<int>UpdateCantofMeta(int idContractPrograming, decimal cantOfmeta );
    }
}
