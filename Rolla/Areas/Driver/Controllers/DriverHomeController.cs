using Microsoft.AspNetCore.Mvc;
using Rolla.Models;
using Rolla.Data;

namespace Rolla.Areas.Driver.Controllers
{
    [Area("Driver")]
    public class DriverHomeController : Controller
    {
        private readonly AppDbContext _context;

        public DriverHomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Driver/DriverHome
        public IActionResult Index()
        {
            return View();
        }

        // POST: Driver/DriverHome
        [HttpPost]
        public IActionResult Index(Rolla.Models.Driver model)
        {
            if (ModelState.IsValid)
            {
                // ذخیره‌سازی در دیتابیس
                _context.Drivers.Add(model);
                _context.SaveChanges();

                // ریدایرکت به صفحه موفقیت (یا می‌تونه یک پیام در همون صفحه باشه)
                return RedirectToAction("DMapView", "DriverHome", new { area = "Driver" });

            }

            return View(model);
        }

        // GET: Driver/DriverHome/Success
        public IActionResult DMapView()
        {
            return View();
        }
    }
}