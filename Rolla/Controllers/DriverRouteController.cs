using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Rolla.Models;

namespace YourApp.Controllers
{
    [Route("Route")]
    public class DriverRouteController : Controller
    {
        private readonly AppDbContext _context;

        public DriverRouteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            var route = new MapRouteDriver
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                CreatedAt = DateTime.UtcNow
            };

            _context.MapRouteDrivers.Add(route);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
