using Microsoft.AspNetCore.Mvc;

namespace Rolla.Areas.Driver.Controllers
{
    [Area("Driver")]
    public class DriverHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
