using GCenapu_Business;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new Buser(_configuration).List());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> search(string text)
        {
            try
            {
                return Ok(await new Buser(_configuration).Search(text));
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("search/id")]
        public async Task<IActionResult> search(int id)
        {
            try
            {
                return Ok(await new Buser(_configuration).Search(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("search/responsible/active")]
        public async Task<IActionResult> SearchActivesTerminal(string terminal)
        {
            try
            {
                return Ok(await new Buser(_configuration).SearchActivesTerminal(terminal));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("search/user")]
        public async Task<IActionResult> SearchUser(string user)
        {
            try
            {
                return Ok(await new Buser(_configuration).SearchUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] login login)
        {
            try
            {
                return Ok(await new Buser(_configuration).Login(login));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance(RUserMaintenance user)
        {
            try
            {
                return Ok(await new Buser(_configuration).Maintenance(user));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
