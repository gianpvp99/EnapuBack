using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UnitController : Controller
    {
        readonly IConfiguration _configuration;
        public UnitController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new Bunit(_configuration).List());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        [HttpGet]
        [Route("list/active")]
        public async Task<IActionResult> ListActive()
        {
            try
            {
                return Ok(await new Bunit(_configuration).ListActive());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string text)
        {
            try
            {
                return Ok(await new Bunit(_configuration).Search(text));
            }
            catch (Exception ex)
            {

                return BadRequest(ex); 
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance(RUnitMaintenance unit)
        {
            try
            {
                return Ok(await new Bunit(_configuration).Maintenance(unit));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


    }
}
