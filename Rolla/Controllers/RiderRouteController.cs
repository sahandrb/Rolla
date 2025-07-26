using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;

namespace Rolla.Controllers
{
    [Route("RiderRoute")]
    public class RiderRouteController : Controller
    {
        private readonly AppDbContext _context;

        public RiderRouteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaveCoordinates")]
        public async Task<IActionResult> SaveCoordinates([FromBody] RouteDto dto)
        {
            if (dto?.Origin == null || dto.Destination == null)
                return BadRequest("مقدار مبدا یا مقصد خالی است.");

            var route = new MapRouteRider
            {
                Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                CreatedAt = DateTime.UtcNow
            };

            _context.MapRouteRiders.Add(route);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
