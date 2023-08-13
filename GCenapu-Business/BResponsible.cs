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
    public class BResponsible:IResponsible
    {
        readonly IConfiguration _configuration;
        public BResponsible(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<Responsible>> List()
        {
            return await new DResponsible(_configuration).List();
        }

        public  async Task<List<Responsible>> List(int idContract)
        {
            return await new DResponsible(_configuration).List(idContract);
        }

        public async Task<int> Maintenance(RResponsibleMaintenance responsible)
        {
            return await new DResponsible(_configuration).Maintenance(responsible);
        }

        public async Task<List<Responsible>> Search(string text)
        {
            return await new DResponsible(_configuration).Search(text);
        }
    }
}
