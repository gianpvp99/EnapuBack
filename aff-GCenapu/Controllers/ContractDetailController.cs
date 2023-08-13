using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractDetailController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public ContractDetailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new BContractDetail(_configuration).List());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet]
        [Route("list/idcontract")]
        public async Task<IActionResult> ListIdContract(int id)
        {
            try
            {
                return Ok(await new BContractDetail(_configuration).ListIdContract(id));
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
                return Ok(await new BContractDetail(_configuration).Search(text));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] RContractDetailMaintenance contractDetail)
        {
            try
            {
                return Ok(await new BContractDetail(_configuration).Maintenance(contractDetail));
            }
            catch (Exception)
            {

                return BadRequest();
            }
            }



    }
}
