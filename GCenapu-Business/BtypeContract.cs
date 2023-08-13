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
    public class BtypeContract : ITypeContracts
    {
        readonly IConfiguration _configuration;
        public BtypeContract(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<TypeContract>> List()
        {
            return await new DTypeContract(_configuration).List();
        }

        public async Task<List<TypeContract>> ListActive()
        {
            return await new DTypeContract(_configuration).ListActive();
        }

        public async Task<int> Maintenance(RTypeContractMaintenance typeContract)
        {
            return await new DTypeContract(_configuration).Maintenance(typeContract);
        }
        public async Task<List<TypeContract>> Search(string text)
        {
            return await new DTypeContract(_configuration).Search(text);
        }
    }
}
