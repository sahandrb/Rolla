namespace Rolla.Models
{
    /// <summary>
    /// Data Transfer Object representing a route with origin and destination coordinates.
    /// Used for passing route data between layers or services.
    /// </summary>
    public class RouteDto
    {
        /// <summary>
        /// Starting point of the route as latitude and longitude.
        /// </summary>
        public LatLng Origin { get; set; } = default!;

        /// <summary>
        /// Ending point of the route as latitude and longitude.
        /// </summary>
        public LatLng Destination { get; set; } = default!;


        
    }

    /// <summary>
    /// Represents a geographic coordinate with latitude and longitude values.
    /// </summary>
    public class LatLng
    {
        /// <summary>
        /// Latitude value in decimal degrees.
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Longitude value in decimal degrees.
        /// </summary>
        public double Lng { get; set; }
    }
}
