namespace Rolla.Models;

        public class RouteDto
        {
            public LatLng Origin { get; set; } = default!;
            public LatLng Destination { get; set; } = default!;
        }

        public class LatLng
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
        }
    


