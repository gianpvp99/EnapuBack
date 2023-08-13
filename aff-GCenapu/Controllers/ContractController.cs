using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public ContractController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List(string idContract)
        {
            try
            {
                return Ok(await new BContract(_configuration).List(idContract));
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string text)
        {
            try
            {
                return Ok(await new BContract(_configuration).Search(text));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] RContractMaintenance contract)
        {
            try
            {
                return Ok(await new BContract(_configuration).Maintenance(contract));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance/add")]
        public async Task<IActionResult> add([FromBody] RContractMaintenanceAdd contract)
        {
            try
            {
                return Ok(await new BContract(_configuration).Add(contract));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
