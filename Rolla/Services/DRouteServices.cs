using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using Rolla.Models;
using Rolla.Data;
using Newtonsoft.Json;

namespace Rolla.Services
{
    public class DRouteServices : IDRouteServices
    {
        private AppDbContext _Context;
        public DRouteServices(AppDbContext context)
        {
            _Context = context;
        }


        public async Task<bool> SaveCordinates(RouteDto dto, DriverDto driverDto)
        {
            try
            {
                var route = new MapRouteDriver
                {
                    Origin = new Point(dto.Origin.Lng, dto.Origin.Lat) { SRID = 4326 },       // نقطه مبدأ با سیستم مختصات جهانی WGS84
                    Destination = new Point(dto.Destination.Lng, dto.Destination.Lat) { SRID = 4326 }, // نقطه مقصد
                    CreatedAt = DateTime.UtcNow,// ثبت زمان ایجاد مسیر به صورت UTC
                    RoutingDCode = driverDto.RoutingDCode,// استفاده از RoutingDCode دریافتی از سشن
                    IsActive = true,
                    NotFound = true
                };

                _Context.MapRouteDrivers.Add(route);
                await _Context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                // در صورت بروز خطا، می‌توان لاگ‌گیری یا مدیریت خطا را انجام داد
                Console.WriteLine($"Error saving coordinates: {ex.Message}");
                return false; // در صورت بروز خطا، false برمی‌گرداند

            }

        }
    }
}