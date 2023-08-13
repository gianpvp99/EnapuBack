using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        readonly IConfiguration _configuration;
        public RoleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new Brole(_configuration).list());
            }
            catch (Exception ex)
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
                return Ok(await new Brole(_configuration).listActive());
            }
            catch (Exception ex)
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
                return Ok(await new Brole(_configuration).Search(text));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance(RRoleMaintenance role)
        {
            try
            {
                return Ok(await new Brole(_configuration).Maintenance(role));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
