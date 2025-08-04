using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rolla.Data;
using Rolla.Models;

namespace Rolla.Areas.Rider.Controllers
{
    public class RiderSearchController : Controller
    {
        private readonly AppDbContext _Context;
        public RiderSearchController(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<IActionResult> SearchDrivers(MapRouteRider RM)
        {
            if (RM == null || RM.Origin == null)
            {
                return BadRequest("Invalid or missing origin coordinates.");
            }

            double radiusKm = 5; // شعاع جستجو به کیلومتر
            double radiusInDegrees = radiusKm / 111.32; // معادل شعاع به درجه برای مقایسه در SRID=4326

            var Drivers =await _Context.MapRouteDrivers
                .Where(d => d.IsActive && d.NotFound &&
                d.Origin.Distance(RM.Origin) <= radiusInDegrees)
                .Select(d => new RSearchViewModel
                {
                Origin = d.Origin,
                    Destination = d.Destination,
                    RoutingDCode = d.RoutingDCode,
                    IsActive = d.IsActive,
                    NotFound = d.NotFound
                  }).ToListAsync();
                

            return View(Drivers);
        }
    }
}
