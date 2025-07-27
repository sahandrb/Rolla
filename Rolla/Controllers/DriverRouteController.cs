using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Rolla.Models;

namespace YourApp.Controllers
{
    // کنترلری برای مدیریت مسیر راننده و ذخیره مختصات جغرافیایی در دیتابیس
    [Route("Route")]
    public class DriverRouteController : Controller
    {
        private readonly AppDbContext _context;

        // تزریق کانتکست دیتابیس از طریق DI
        public DriverRouteController(AppDbContext context)
        {
            _context = context;
        }

        // POST: /Route/SaveCoordinates
        // دریافت مختصات مبدأ و مقصد از سمت کلاینت (معمولاً از طریق JS با fetch یا axios)
        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            // ایجاد یک مسیر جدید بر اساس مختصات دریافتی، با فرمت نقطه جغرافیایی و SRID استاندارد
            var route = new MapRouteDriver
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },       // نقطه مبدأ با سیستم مختصات جهانی WGS84
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 }, // نقطه مقصد
                CreatedAt = DateTime.UtcNow // ثبت زمان ایجاد مسیر به صورت UTC
            };

            // افزودن مسیر به دیتابیس و ذخیره‌سازی به صورت غیرهمزمان
            _context.MapRouteDrivers.Add(route);
            await _context.SaveChangesAsync();

            // بازگرداندن وضعیت موفقیت به کلاینت (200 OK)
            return Ok();
        }
    }
}
