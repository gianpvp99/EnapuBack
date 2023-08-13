using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public interface IUnit
    {
        Task<int>Maintenance(RUnitMaintenance unit);
        Task<List<Unit>>List();
        Task<List<Unit>> ListActive();
        Task<List<Unit>>Search(string text);
    }
}
