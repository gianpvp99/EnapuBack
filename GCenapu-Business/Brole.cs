using GCenapu_Contracts;
using GCenapu_Data;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Business
{
    public class Brole : IRole
    {
        readonly IConfiguration _configuration;

        public Brole(IConfiguration configuration)
        {
            this._configuration=configuration;
        }
        public async Task<List<Role>> list()
        {
            return await new DRole(_configuration).list();
        }

        public async Task<List<Role>> listActive()
        {
            return await new DRole(_configuration).listActive();
        }

        public async Task<int> Maintenance(RRoleMaintenance role)
        {
           return await new DRole(_configuration).Maintenance(role);
        }

        public async Task<List<Role>> Search(string text)
        {
            return await new DRole(_configuration).Search(text);
        }
    }
}
