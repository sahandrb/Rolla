using Microsoft.AspNetCore.Mvc;

namespace Rolla.Areas.Rider.Controllers
{
    public class RiderHomeController : Controller
    {
        [Area("Rider")] // Specifies that this action belongs to the "Rider" area
        public IActionResult Index()
        {
            return View(); // Returns the default view for RiderHome/Index
        }
    }
}
