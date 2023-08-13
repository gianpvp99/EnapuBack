using GCenapu_Contracts;
using GCenapu_Entity;
using GCenapu_Entity.common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCenapu_Data;
using GCenapu_Entity.Request;
using static System.Net.Mime.MediaTypeNames;

namespace GCenapu_Contracts     
{
    public class BunitMeasurement : IunitMeasurement
    {
        readonly IConfiguration _configuration;


        public BunitMeasurement(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<UnitMeasurement>> List()
        {
            return await new DUnitMeasurement(_configuration).List();
        }

        public async Task<int> Maintenance(RUnitMeasurementMaintenance unitMeasurement)
        {
            return await new DUnitMeasurement(_configuration).Maintenance(unitMeasurement);
        }

        public async Task<List<UnitMeasurement>> Search(string text)
        {
            return await new DUnitMeasurement(_configuration).Search(text);
        }

        public async Task<List<UnitMeasurement>> Search(int id)
        {
            return await new DUnitMeasurement(_configuration).Search(id);
        }
    }
}
