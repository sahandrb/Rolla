using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Rolla.Models;

namespace YourApp.Controllers
{
    [Route("Route")]
    public class RouteController : Controller
    {
        private readonly AppDbContext _context;

        public RouteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            var route = new MapRoute
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                CreatedAt = DateTime.UtcNow
            };

            _context.MapRoutes.Add(route);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
