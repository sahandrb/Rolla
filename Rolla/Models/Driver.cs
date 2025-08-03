using System.ComponentModel.DataAnnotations;

namespace Rolla.Models
{
    // Represents a driver in the Rolla application
    public class Driver
    {
        public String Name { get; set; }      // Driver's full name
        [Key]
        public int DriverId { get; set; }     // Unique identifier for the driver
        public int TypeOfCar { get; set; }
        
        public int RoutingDCode { get; set; }
    }
}
