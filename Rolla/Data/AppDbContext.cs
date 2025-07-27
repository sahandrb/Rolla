using Microsoft.EntityFrameworkCore;
using Rolla.Models;

namespace Rolla.Data
{
    /// <summary>
    /// Entity Framework Core database context for the Rolla application.
    /// Manages access to domain entities: Drivers, Riders, and their associated map routes.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes the database context with the given options.
        /// Typically configured in the Program.cs 
        /// </summary>
        /// <param name="options">Configuration options for the DbContext</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Database set representing all Driver entities in the system.
        /// </summary>
        public DbSet<Driver> Drivers { get; set; }

        /// <summary>
        /// Database set representing all Rider entities in the system.
        /// </summary>
        public DbSet<Rider> Riders { get; set; }

        /// <summary>
        /// Join table for associating Drivers with their map routes.
        /// Used to track route assignments or scheduling.
        /// </summary>
        public DbSet<MapRouteDriver> MapRouteDrivers { get; set; }

        /// <summary>
        /// Join table for associating Riders with their map routes.
        /// Used to manage ride participation or preferences.
        /// </summary>
        public DbSet<MapRouteRider> MapRouteRiders { get; set; }
    }
}
