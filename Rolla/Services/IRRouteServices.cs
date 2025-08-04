using Rolla.Models;


namespace Rolla.Services
{
    public interface IRRouteServices
    {
        Task<bool> SaveCordinates(RouteDto Dto, RiderDto driverDto);
    }
}
