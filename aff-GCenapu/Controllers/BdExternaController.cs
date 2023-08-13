using GCenapu_Business.BdExterna;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BdExternaController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public BdExternaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("list/cliente")]
        public async Task<IActionResult> ListCliente(string idTerminal)
        {
            try
            {
                return Ok(await new BDataExterna(_configuration).ListCliente(idTerminal));
            }
            catch (Exception ex)
            {

               return BadRequest(ex);
            }
        }
       
        [HttpGet]
        [Route("list/tarifa")]
        public async Task<IActionResult> ListTarifa(string idTerminal , string idServicio)
        {
            try
            {
                return Ok(await new BDataExterna(_configuration).ListTarifa(idTerminal, idServicio));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("list/terminal")]
        public async Task<IActionResult> ListTerminal()
        {
            try
            {
                return Ok(await new BDataExterna(_configuration).ListTerminal());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("list/tipo/tarifa")]
        public async Task<IActionResult> ListTipoTarifa(string idTerminal)
        {
            try
            {
                return Ok(await new BDataExterna(_configuration).ListTipoTarifa(idTerminal));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
