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
    public class BContract:IContract
    {
        readonly IConfiguration _configuration;
        public BContract(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<int> Add(RContractMaintenanceAdd contract)
        {
            return await new DContract(_configuration).Add(contract);
        }

        public async Task<List<Contract>> List(string idPuerto)
        {
            return await new DContract(_configuration).List(idPuerto);
        }

        public async Task<int> Maintenance(RContractMaintenance contract)
        {
            return await new DContract(_configuration).Maintenance(contract);
        }

        public async Task<List<Contract>> Search(string text)
        {
            return await new DContract(_configuration).Search(text);
        }
    }
}
