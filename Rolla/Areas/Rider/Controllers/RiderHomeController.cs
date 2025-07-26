using Microsoft.AspNetCore.Mvc;
using Rolla.Models;
using Rolla.Data;

namespace Rolla.Areas.Rider.Controllers
{
    [Area("Rider")]
    public class RiderHomeController : Controller
    {
        private readonly AppDbContext _context;

        public RiderHomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rider/RiderHome
        public IActionResult Index()
        {
            return View();
        }

        // POST: Rider/RiderHome
        [HttpPost]
        public IActionResult Index(Rolla.Models.Rider model)
        {
            if (ModelState.IsValid)
            {
                _context.Riders.Add(model);
                _context.SaveChanges();

                return RedirectToAction("RMapView", "RiderHome", new { area = "Rider" });
            }

            return View(model);
        }

        // GET: Rider/RiderHome/RMapView
        public IActionResult RMapView()
        {
            return View();
        }
    }
}
