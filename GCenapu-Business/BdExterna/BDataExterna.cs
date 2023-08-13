using GCenapu_Contracts.BsExterna;
using GCenapu_Data.BdExterna;
using GCenapu_Entity.BdExterna;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Business.BdExterna
{
    public class BDataExterna : IDataExterna
    {
        readonly IConfiguration _configuration;
        public BDataExterna(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<EnapuPrincipal_Cliente>> ListCliente(string idTerminal)
        {
            return await new DDataExterna(_configuration).ListCliente(idTerminal);
        }

        public async Task<List<EnapuPrincipal_Tarifa>> ListTarifa(string idTerminal, string idServicio)
        {
            return await new DDataExterna(_configuration).ListTarifa(idTerminal, idServicio);
        }

        public async Task<List<EnapuPrincipal_TerminalPortuario>> ListTerminal()
        {
            return await new DDataExterna(_configuration).ListTerminal();
        }

        public async Task<List<EnapuPrincipal_TipoTarifa>> ListTipoTarifa(string idTerminal)
        {
            return await new DDataExterna(_configuration).ListTipoTarifa(idTerminal);
        }
    }
}
