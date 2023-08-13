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
    public class Bunit:IUnit
    {
        readonly IConfiguration _configuration;

        public Bunit(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<List<Unit>> List()
        {
            return await new DUnit(_configuration).List();
        }

        public async Task<List<Unit>> ListActive()
        {
            return await new DUnit(_configuration).ListActive();
        }

        public async Task<int> Maintenance(RUnitMaintenance unit)
        {
            return await new DUnit(_configuration).Maintenance(unit);
        }

        public async Task<List<Unit>> Search(string text)
        {
            return await new DUnit(_configuration).Search(text);
        }
    }
}

