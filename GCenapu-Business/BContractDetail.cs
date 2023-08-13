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
    public class BContractDetail:IContractDetail
    {
        readonly IConfiguration _configuration;
        public BContractDetail(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<ContractDetail>> List()
        {
            return await new DContractDetail(_configuration).List();
        }

        public async Task<List<ContractDetail>> ListIdContract(int id)
        {
            return await new DContractDetail(_configuration).ListIdContract(id);
        }

        public async Task<int> Maintenance(RContractDetailMaintenance contractDetail)
        {
            return await new DContractDetail(_configuration).Maintenance(contractDetail);
        }

        public async Task<List<ContractDetail>> Search(string text)
        {
            return await new DContractDetail(_configuration).Search(text);
        }
    }
}
