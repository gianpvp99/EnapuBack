using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface  ITypeContracts
    {
        Task<int> Maintenance(RTypeContractMaintenance typeContract);
        Task<List<TypeContract>> Search(string text);
        Task<List<TypeContract>> List();
        Task<List<TypeContract>> ListActive();
    }
}
