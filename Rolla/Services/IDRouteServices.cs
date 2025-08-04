using Rolla.Models;


namespace Rolla.Services
{
    public interface IDRouteServices
    { 
        Task<bool> SaveCordinates(RouteDto dto, DriverDto driverDto);
    }
}
