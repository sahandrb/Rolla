using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;

namespace Rolla.Controllers
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
            // بررسی اعتبار ورودی‌ها: اگر مبدا یا مقصد خالی بود، خطا بازگردانده می‌شود
            if (dto?.Origin == null || dto.Destination == null)
                return BadRequest("مقدار مبدا یا مقصد خالی است.");

            // ایجاد شیء جدید از مسیر با تبدیل مختصات به ساختار Point (دارای SRID استاندارد 4326)
            var route = new MapRouteRider
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                CreatedAt = DateTime.UtcNow
            };

            // افزودن مسیر به دیتابیس و ذخیره تغییرات به‌صورت async
            _context.MapRouteRiders.Add(route);
            await _context.SaveChangesAsync();

            // بازگرداندن وضعیت موفقیت‌آمیز به کلاینت (status code 200)
            return Ok();
        }
    }
}
