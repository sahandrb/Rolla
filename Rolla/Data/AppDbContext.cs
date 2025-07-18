using Microsoft.EntityFrameworkCore;
using Rolla.Models;
namespace Rolla.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Rider> Riders { get; set; }

    }
}
