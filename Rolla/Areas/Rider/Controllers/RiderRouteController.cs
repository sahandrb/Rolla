using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Newtonsoft.Json;
using Rolla.Services;

namespace Rolla.Areas.Rider.Controllers
{
    // کنترلر مربوط به دریافت و ذخیره مختصات مسیر مسافر (رکورد مسیر جغرافیایی)
    [Route("RiderRoute")]
    public class RiderRouteController : Controller
    {
        private IRRouteServices _rRouteServices;
        private readonly AppDbContext _context;

        // سازنده کلاس برای دریافت وابستگی به دیتابیس از طریق DI
        public RiderRouteController(AppDbContext context , IRRouteServices rRouteServices)
        {
            _context = context;
            _rRouteServices = rRouteServices;
        }

        // POST: RiderRoute/SaveCoordinates
        // دریافت مختصات مبدا و مقصد از کلاینت و ذخیره آن به‌صورت Route در دیتابیس
        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            var Json = HttpContext.Session.GetString("RiderDto");
            if (String.IsNullOrEmpty(Json))
            {
                return BadRequest("RiderDto Not Found in Session");
            }
            var riderDto = JsonConvert.DeserializeObject<RiderDto>(Json);
            var Success = await _rRouteServices.SaveCordinates(dto, riderDto);
            if (!Success)
            {
                return StatusCode(500, "An error occurred while saving coordinates.");
            }
            return RedirectToAction("SearchDrivers", "RiderSearch", new { area = "Rider" });


        }
    }
}
