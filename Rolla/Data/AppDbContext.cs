using Microsoft.EntityFrameworkCore;
using Rolla.Models;

namespace Rolla.Data
{
    // Database context for the Rolla application managing Drivers and Riders tables
    public class AppDbContext : DbContext
    {
        // Constructor accepting options for configuring the context
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Driver> Drivers { get; set; }  // Represents the Drivers table
        public DbSet<Rider> Riders { get; set; }    // Represents the Riders table
        public DbSet<MapRoute> MapRoutes { get; set; }

    }
}
