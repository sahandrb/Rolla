using NetTopologySuite.Geometries;

namespace Rolla.Models
{
    /// <summary>
    /// Represents a driver's route on the map with defined origin and destination points.
    /// This entity tracks when the route was created for auditing or scheduling purposes.
    /// </summary>
    public class MapRouteDriver
    {
        /// <summary>
        /// Primary key identifier for the route record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Geographic point representing the start location of the route.
        /// Uses NetTopologySuite's <see cref="Point"/> for spatial data support.
        /// </summary>
        public Point Origin { get; set; }

        /// <summary>
        /// Geographic point representing the end location of the route.
        /// </summary>
        public Point Destination { get; set; }

        /// <summary>
        /// Timestamp indicating when this route record was created.
        /// Useful for tracking and ordering route entries.
        /// </summary>
        public DateTime CreatedAt { get; set; }


        public int RoutingDCode { get; set; } = default!;
    }
}
