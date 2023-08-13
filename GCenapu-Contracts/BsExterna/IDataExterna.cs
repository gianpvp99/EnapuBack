using GCenapu_Entity.BdExterna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Contracts.BsExterna
{
    public interface IDataExterna
    {
        Task<List<EnapuPrincipal_Cliente>> ListCliente(string idTerminal);
        Task<List<EnapuPrincipal_Tarifa>> ListTarifa(string idTerminal ,string idServicio);
        Task<List<EnapuPrincipal_TerminalPortuario>> ListTerminal();
        Task<List<EnapuPrincipal_TipoTarifa>> ListTipoTarifa(string idTerminal);
    }
}
