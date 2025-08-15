using Microsoft.AspNetCore.Mvc;
using Rolla.Models;
using Rolla.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Rolla.Areas.Rider.Controllers
{
    // این کنترلر مربوط به بخش Rider است و کار مدیریت صفحه اصلی مسافر را بر عهده دارد
    [Area("Rider")]
    public class RiderHomeController : Controller
    {
        private readonly AppDbContext _context;

        // سازنده کنترلر که کانتکست دیتابیس را از طریق تزریق وابستگی دریافت می‌کند
        // این کانتکست برای دسترسی به داده‌های مربوط به مسافران استفاده می‌شود
        public RiderHomeController(AppDbContext context)
        {
            _context = context;
        }

        // متد مربوط به درخواست GET که صفحه اصلی مسافر را نمایش می‌دهد
        // این صفحه معمولاً شامل فرم ثبت اطلاعات مسافر است تا بتواند درخواست سفر را آغاز کند
        public IActionResult Index()
        {
            return View();
        }

        // متد مربوط به درخواست POST که زمانی اجرا می‌شود که فرم ثبت اطلاعات مسافر ارسال شود
        // در این متد داده‌های دریافتی اعتبارسنجی می‌شوند و اگر صحیح باشند، اطلاعات مسافر در دیتابیس ذخیره می‌شود
        // پس از ذخیره موفق، کاربر به صفحه دیگری هدایت می‌شود که نقشه یا وضعیت سفر را نمایش می‌دهد
        // در صورت وجود خطا در اعتبارسنجی، مجدداً همان فرم به همراه پیام خطا به کاربر نمایش داده می‌شود
        [HttpPost]
        public async Task<IActionResult> Index(Rolla.Models.Rider model)
        {
            if (ModelState.IsValid) // بررسی صحت داده‌های ورودی فرم
            {
                _context.Riders.Add(model); // اضافه کردن اطلاعات مسافر به جدول Riders در دیتابیس
                _context.SaveChanges(); // ذخیره تغییرات در دیتابیس
                model.RoutingRCode = model.RiderId + 2000;

                _context.Riders.Update(model); // به‌روزرسانی اطلاعات مسافر در دیتابیس
                _context.SaveChanges(); // ذخیره تغییرات در دیتابیس


                var Dto = new RiderDto
                {
                    RoutingRCode = model.RiderId + 2000 // فرض بر این است که RoutingRCode بر اساس RiderId محاسبه می‌شود
                };
                var RiderDto = System.Text.Json.JsonSerializer.Serialize(Dto); // سریالیزه کردن داده‌ها به فرمت JSON
                HttpContext.Session.SetString("RiderDto", RiderDto); // ذخیره داده‌های مسافر در سشن برای دسترسی در آینده

                var Claims = new List<Claim>
                {
                    new Claim("Name" , model.name),
                    new Claim("RoutingRCode", model.RoutingRCode.ToString())
                };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme); // ایجاد یک شیء ClaimsIdentity برای مدیریت هویت کاربر
                var Principal = new ClaimsPrincipal(Identity); // ایجاد یک شیء ClaimsPrincipal برای مدیریت هویت کاربر
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, // استفاده از کوکی برای احراز هویت
                    Principal, // شیء ClaimsPrincipal که شامل اطلاعات کاربر است
                    new AuthenticationProperties { IsPersistent = true , ExpiresUtc=DateTimeOffset.UtcNow.AddHours(7) } // تنظیم ویژگی‌های احراز هویت
                );



                // انتقال کاربر به صفحه نمایش نقشه یا وضعیت سفر در صورت موفقیت ذخیره سازی
                return RedirectToAction("RMapView", "RiderHome", new { area = "Rider" });
            }

            // اگر داده‌ها معتبر نباشند، فرم به همراه خطاها دوباره نمایش داده می‌شود
            return View(model);
        }

        // متدی که صفحه نقشه یا وضعیت مسافر را نمایش می‌دهد
        // این صفحه پس از ثبت موفق اطلاعات مسافر نمایش داده می‌شود
        public IActionResult RMapView()
        {
            return View();
        }
    }
}
