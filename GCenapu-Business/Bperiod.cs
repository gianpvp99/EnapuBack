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
    public class Bperiod : Iperiod
    {
        readonly IConfiguration _configuration;
        public Bperiod(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<Period>> List()
        {
            return await new DPeriod(_configuration).List();
        }

        public async Task<List<Period>> ListActive()
        {
            return await new DPeriod(_configuration).ListActive();
        }

        public async Task<int> Maintenance(RPeriodMaintenance period)
        {
            return await new DPeriod(_configuration).Maintenance(period);
        }

        public async Task<List<Period>> Search(string text)
        {
            return await new DPeriod(_configuration).Search(text);
        }
    }
}
