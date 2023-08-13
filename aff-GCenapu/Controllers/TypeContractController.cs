using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeContractController : Controller
    {

        readonly IConfiguration _configuration;
        public TypeContractController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new BtypeContract(_configuration).List());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("list/active")]
        public async Task<IActionResult> ListActive()
        {
            try
            {
                return Ok(await new BtypeContract(_configuration).ListActive());
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
                return Ok(await new BtypeContract(_configuration).Search(text));
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] RTypeContractMaintenance typeContract)
        {
            return Ok(await new BtypeContract(_configuration).Maintenance(typeContract));

        } 
    }
}
