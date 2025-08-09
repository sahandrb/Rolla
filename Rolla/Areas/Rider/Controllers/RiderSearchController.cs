using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Rolla.Data;
using Rolla.Models;

namespace Rolla.Areas.Rider.Controllers
{
    [Area("Rider")]
    public class RiderSearchController : Controller
    {  

        public IActionResult SearchMethod()
        {
            return View();
        }



    }
}
