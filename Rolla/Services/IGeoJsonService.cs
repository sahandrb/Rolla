using Rolla.Models;

namespace Rolla.Services
{
    public interface IGeoJsonService
    {
        Object BuildGeoJsonFromEntitys(IEnumerable<MapRouteDriver> locations);
    }
}
