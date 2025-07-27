using Microsoft.AspNetCore.Mvc;
using Rolla.Models;
using Rolla.Data;

namespace Rolla.Areas.Driver.Controllers
{
    // کنترلر مرتبط با بخش "Driver" برای مدیریت عملیات صفحه خانه راننده
    [Area("Driver")]
    public class DriverHomeController : Controller
    {
        private readonly AppDbContext _context;

        // سازنده کلاس کنترلر، دریافت وابستگی به دیتابیس از طریق DI
        public DriverHomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Driver/DriverHome
        // نمایش صفحه خانه راننده بدون هیچ ورودی خاص (فرم ورود اطلاعات یا داشبورد)
        public IActionResult Index()
        {
            return View();
        }

        // POST: Driver/DriverHome
        // این متد فرم اطلاعات راننده را از کاربر دریافت کرده و در دیتابیس ذخیره می‌کند
        [HttpPost]
        public IActionResult Index(Rolla.Models.Driver model)
        {
            if (ModelState.IsValid)
            {
                // اگر مدل معتبر بود، داده‌ها را به جدول Driver اضافه می‌کنیم
                _context.Drivers.Add(model);
                _context.SaveChanges();

                // پس از ثبت موفقیت‌آمیز، کاربر به نمای نقشه هدایت می‌شود
                return RedirectToAction("DMapView", "DriverHome", new { area = "Driver" });
            }

            // اگر اعتبارسنجی مدل شکست خورد، صفحه با خطاها مجدداً نمایش داده می‌شود
            return View(model);
        }

        // GET: Driver/DriverHome/Success
        // نمایش نمایی (مثلاً نقشه یا وضعیت) پس از ثبت موفق راننده
        public IActionResult DMapView()
        {
            return View();
        }
    }
}
