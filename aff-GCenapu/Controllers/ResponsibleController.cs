using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public ResponsibleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new BResponsible(_configuration).List());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet]
        [Route("list_idContract")]
        public async Task<IActionResult> List(int idContract)
        {
            try
            {
                return Ok(await new BResponsible(_configuration).List(idContract));
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
                return Ok(await new BResponsible(_configuration).Search(text));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] RResponsibleMaintenance responsible)
        {
            try
            {
                return Ok(await new BResponsible(_configuration).Maintenance(responsible));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
