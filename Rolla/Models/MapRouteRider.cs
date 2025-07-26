using NetTopologySuite.Geometries;


namespace Rolla.Models
{
    public class MapRouteRider
    {
        public int Id { get; set; }
        public Point Origin { get; set; }
        public Point Destination { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
