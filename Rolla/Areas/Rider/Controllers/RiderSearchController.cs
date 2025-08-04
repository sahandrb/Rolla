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
        private readonly AppDbContext _Context;

        public RiderSearchController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SearchDrivers(double lat, double lng)
        {
            if (lat == 0 || lng == 0)
            {
                return BadRequest("Missing or invalid origin coordinates.");
            }

            // ساخت نقطه مبدأ بر اساس مختصات ورودی
            var origin = new Point(lng, lat) { SRID = 4326 };

            double radiusKm = 5;
            double radiusInDegrees = radiusKm / 111.32;

            var drivers = await _Context.MapRouteDrivers
                .Where(d =>
                    d.IsActive &&
                    d.NotFound &&
                    d.Origin != null &&
                    d.Origin.Distance(origin) <= radiusInDegrees)
                .Select(d => new RSearchViewModel
                {
                    Origin = d.Origin,
                    Destination = d.Destination,
                    RoutingDCode = d.RoutingDCode,
                    IsActive = d.IsActive,
                    NotFound = d.NotFound
                })
                .ToListAsync();

            return View(drivers);
        }
    }
}
