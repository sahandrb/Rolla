using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Newtonsoft.Json;
namespace Rolla.Services
{
    public class RRouteServices : IRRouteServices
    {
        private AppDbContext _Context;

        public RRouteServices(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<bool> SaveCordinates(RouteDto dto, RiderDto riderDto)
        {
            try
            {
                var route = new MapRouteRider
                {
                    Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },
                    Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 },
                    CreatedAt = DateTime.UtcNow,
                    RoutingDCode = riderDto.RoutingRCode, // استفاده از RoutingDCode دریافتی از سشن
                    IsActive = true,
                    NotFound = true

                };
                _Context.MapRouteRiders.Add(route);
                await _Context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving coordinates: {ex.Message}");
                return false;
            }
        }
    }
}
