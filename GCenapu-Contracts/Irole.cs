using GCenapu_Entity;
using GCenapu_Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts
{
    public  interface IRole
    {
        Task<int> Maintenance(RRoleMaintenance role);
        Task<List<Role>> list();
        Task<List<Role>> Search(string text);
        Task<List<Role>> listActive();
    }
}
