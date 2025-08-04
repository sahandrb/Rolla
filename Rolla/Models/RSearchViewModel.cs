using NetTopologySuite.Geometries;

namespace Rolla.Models
{
    public class RSearchViewModel
    {
        public Point Origin { get; set; }


        public Point Destination { get; set; }

        public double OriginLat => Origin.Y;
        
        public double OriginLng => Origin.X;

        public double DestinationLat => Destination.Y;

        public double DestinationLng => Destination.X;

        public int RoutingDCode { get; set; } = default!;

        public bool IsActive { get; set; } = true; 

        public bool NotFound { get; set; } = true;
    }
}
