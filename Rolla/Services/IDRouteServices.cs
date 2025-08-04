using Rolla.Models;
using Rolla.Models;
using Rolla.Controllers;


namespace Rolla.Services
{
    public interface IDRouteServices
    { 
        Task<bool> SaveCordinates(RouteDto dto, DriverDto driverDto);
    }
}
