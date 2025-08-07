using Rolla.Models;

namespace Rolla.Services
{
    public class GeoJsonService : IGeoJsonService
    {
        public object BuildGeoJsonFromEntitys(IEnumerable<MapRouteDriver> locations)
        {
            var features = locations.Select(l => new GeoJsonFeature
            {
                geometry = new Geometry
                {
                    Coordinates = new double[] { l.Origin.X, l.Origin.Y }
                },
                Properties = new Dictionary<string, object>
                { 
                    { "routingDCode", l.RoutingDCode }

                }
            })
                .ToList();
            return new
            {
                Type = "FeatureCollection",
                Features = features 
            };


        }

    }
}
