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
using static System.Net.Mime.MediaTypeNames;

namespace GCenapu_Business
{
    public class BContractPrograming:IContractPrograming
    {
        readonly IConfiguration _configuration;
        public BContractPrograming(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<ContractPrograming>> List()
        {
            return await new DContractPrograming(_configuration).List();
        }
        public async Task<List<ContractPrograming>> ListDestail(int id)
        {
            return await new DContractPrograming(_configuration).ListDestail(id);
        }

        public async Task<int> Maintenance(RContractProgramingMaintenance contractPrograming)
        {
            return await new DContractPrograming(_configuration).Maintenance(contractPrograming);
        }

        public async Task<List<ContractPrograming>> Search(string text)
        {
            return await new DContractPrograming(_configuration).Search(text);
        }

        public async Task<int> UpdateCantofMeta(int idContractPrograming, decimal cantOfmeta)
        {
            return await new DContractPrograming(_configuration).UpdateCantofMeta(idContractPrograming, cantOfmeta);
        }
    }
}
