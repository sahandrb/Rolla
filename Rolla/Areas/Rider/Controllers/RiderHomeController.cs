using Microsoft.AspNetCore.Mvc;
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



        
        public IActionResult Index()
        {
            return View(); // Returns the default view for RiderHome/Index
        }

        [HttpPost]
        public IActionResult Index(Rolla.Models.Rider rider)
        {
            if (ModelState.IsValid)
            {
                _context.Riders.Add(rider);
                _context.SaveChanges();
                return RedirectToAction("RMapView", "RiderHome", new { area = "Rider" });
            }
            return View(rider);
        }
        public IActionResult RMapView()
        {
            return View();
        }
            
    }
}
