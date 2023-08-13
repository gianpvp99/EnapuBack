using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractProgramingController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public ContractProgramingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new BContractPrograming(_configuration).List());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet]
        [Route("list/detail")]
        public async Task<IActionResult> ListDestail(int id)
        {
            try
            {
                return Ok(await new BContractPrograming(_configuration).ListDestail(id));
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
                return Ok(await new BContractPrograming(_configuration).Search(text));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] RContractProgramingMaintenance contractPrograming)
        {
            try
            {
                return Ok(await new BContractPrograming(_configuration).Maintenance(contractPrograming));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("UpdateCantofMeta")]
        public async Task<IActionResult> UpdateCantofMeta(int idContractPrograming, decimal cantOfmeta)
        {
            try
            {
                return Ok(await new BContractPrograming(_configuration).UpdateCantofMeta(idContractPrograming, cantOfmeta));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
