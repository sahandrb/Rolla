namespace Rolla.Models
{
    public class GeoJsonFeature
    {
        public String Type => "Feature";

        public Geometry geometry { get; set; } = new Geometry();

        public Dictionary<string, object> Properties { get; set; }

        public int RoutingDCode { get; set; }
    }
    
    public class Geometry
    {
        public string Type => "Point";
        public double[] Coordinates { get; set; }
    }
}
