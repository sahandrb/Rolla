using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Rolla.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rolla.BackGroundServices
{
    public class RouteCleanerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RouteCleanerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                bool hasChanges = false;

                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var now = DateTime.UtcNow;

                var expiredDrivers = db.MapRouteDrivers
                    .Where(r => r.IsActive && r.CreatedAt <= now.AddMinutes(-10))
                    .ToList();

                if (expiredDrivers.Any())
                {
                    foreach (var route in expiredDrivers)
                        route.IsActive = false;

                     hasChanges = true;
                }


                var expiredRiders = db.MapRouteRiders
               .Where(r => r.IsActive && r.CreatedAt <= now.AddMinutes(-10))
               .ToList();

                if (expiredRiders.Any())
                {
                    foreach (var route in expiredRiders)
                        route.IsActive = false;

                    hasChanges = true;
                }
                if (hasChanges)
                {
                    await db.SaveChangesAsync();
                }

                // اجرای این بررسی هر 1 دقیقه
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
