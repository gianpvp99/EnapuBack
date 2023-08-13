
using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodController : Controller
    {
        readonly IConfiguration _configuration;

        public PeriodController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List() {
            try
            {
                return Ok(await new Bperiod(_configuration).List());
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
                return Ok(await new Bperiod(_configuration).ListActive());
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
                return Ok(await new Bperiod(_configuration).Search(text));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public  async Task<IActionResult> Maintenance([FromBody] RPeriodMaintenance period)
        {
            try
            {
                return Ok(await new Bperiod(_configuration).Maintenance(period));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
