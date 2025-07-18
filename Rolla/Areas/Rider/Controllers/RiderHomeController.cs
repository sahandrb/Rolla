using Microsoft.AspNetCore.Mvc;

namespace Rolla.Areas.Rider.Controllers
{
    public class RiderHomeController : Controller
    {
        [Area("Rider")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
