namespace Rolla.Models
{
    // Represents a rider in the Rolla application
    public class Rider
    {
        public string name { get; set; }       // Rider's full name
        public int RiderId { get; set; }       // Unique identifier for the rider
        public int RiderType { get; set; }     // Category or type of the rider
    }
}
