using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Newtonsoft.Json;
using Rolla.Services;

namespace Rolla.Areas.Driver.Controllers
{
    // کنترلری برای مدیریت مسیر راننده و ذخیره مختصات جغرافیایی در دیتابیس
    [Route("Route")]
    public class DriverRouteController : Controller
    {
        private readonly AppDbContext _context;
        private IDRouteServices _routeServices;
        // تزریق کانتکست دیتابیس از طریق DI
        public DriverRouteController(AppDbContext context ,IDRouteServices routeServices )
        {
            _context = context;
            _routeServices = routeServices;
        }

        // POST: /Route/SaveCoordinates
        // دریافت مختصات مبدأ و مقصد از سمت کلاینت (معمولاً از طریق JS با fetch یا axios)
        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            var Json = HttpContext.Session.GetString("DriverDto");
            if (string.IsNullOrEmpty(Json))
            {
                return BadRequest("DriverDto not found in session.");
            }
            var driverDto = JsonConvert.DeserializeObject<DriverDto>(Json);

            var Success = await _routeServices.SaveCordinates(dto, driverDto);
            if (Success)
            {
                return Ok("Coordinates saved successfully.");
            }
            else
            {
                return StatusCode(500, "An error occurred while saving coordinates.");
            }


        }
    }
}
