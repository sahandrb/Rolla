using Microsoft.AspNetCore.Mvc;

namespace Rolla.Areas.Driver.Controllers
{
    [Area("Driver")] // Specifies this controller belongs to the "Driver" area
    public class DriverHomeController : Controller
    {
        // Handles requests to /Driver/DriverHome/Index and returns the default view
        public IActionResult Index()
        {
            return View();
        }
    }
}
