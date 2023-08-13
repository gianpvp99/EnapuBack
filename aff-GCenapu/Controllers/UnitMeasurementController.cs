using GCenapu_Business;
using GCenapu_Contracts;
using GCenapu_Entity;
using GCenapu_Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace aff_GCenapu.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UnitMeasurementController : Controller
    {
        readonly IConfiguration _configuration;
        public UnitMeasurementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await new BunitMeasurement(_configuration).List());
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
                return Ok(await new BunitMeasurement(_configuration).Search(text));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("search/id")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                return Ok(await new BunitMeasurement(_configuration).Search(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        [HttpPost]
        [Route("maintenance")]
        public async Task<IActionResult> Maintenance(RUnitMeasurementMaintenance unitMeasurement)
        {
            try
            {
                return Ok(await new BunitMeasurement(_configuration).Maintenance(unitMeasurement));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
    