using NetTopologySuite.Geometries;

namespace Rolla.Models
{
    /// <summary>
    /// Represents a rider's route on the map, defined by origin and destination points.
    /// Tracks creation time to assist with route management and history.
    /// </summary>
    public class MapRouteRider
    {
        /// <summary>
        /// Unique identifier for this rider route record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Starting geographic location of the rider's route.
        /// Utilizes NetTopologySuite's spatial <see cref="Point"/> type.
        /// </summary>
        public Point Origin { get; set; }

        /// <summary>
        /// Ending geographic location of the rider's route.
        /// </summary>
        public Point Destination { get; set; }

        /// <summary>
        /// Date and time when this route record was created.
        /// Used for auditing and chronological ordering of routes.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public int RoutingDCode { get; set; } = default!;


        public bool IsActive { get; set; } = true; // Indicates if the route is currently active or not

        public bool NotFound { get; set; } = true;

    }
}
