using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Newtonsoft.Json;

namespace Rolla.Areas.Rider.Controllers
{
    // کنترلر مربوط به دریافت و ذخیره مختصات مسیر مسافر (رکورد مسیر جغرافیایی)
    [Route("RiderRoute")]
    public class RiderRouteController : Controller
    {
        private readonly AppDbContext _context;

        // سازنده کلاس برای دریافت وابستگی به دیتابیس از طریق DI
        public RiderRouteController(AppDbContext context)
        {
            _context = context;
        }

        // POST: RiderRoute/SaveCoordinates
        // دریافت مختصات مبدا و مقصد از کلاینت و ذخیره آن به‌صورت Route در دیتابیس
        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {


            var Json = HttpContext.Session.GetString("RiderDto");
            if (string.IsNullOrEmpty(Json))
            {
                // اگر سشن خالی بود، وضعیت خطا برمی‌گرداند
                return BadRequest("Session data is missing.");
            }
            var dtoR = JsonConvert.DeserializeObject<RiderDto>(Json);
            // ایجاد شیء جدید از مسیر با تبدیل مختصات به ساختار Point (دارای SRID استاندارد 4326)
            var route = new MapRouteRider
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                CreatedAt = DateTime.UtcNow,
                RoutingDCode = dtoR.RoutingRCode // استفاده از RoutingDCode دریافتی از سشن


            };

            // افزودن مسیر به دیتابیس و ذخیره تغییرات به‌صورت async
            _context.MapRouteRiders.Add(route);
            await _context.SaveChangesAsync();

            // بازگرداندن وضعیت موفقیت‌آمیز به کلاینت (status code 200)
            return Ok();
        }
    }
}
