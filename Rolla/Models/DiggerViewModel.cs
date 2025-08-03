using NetTopologySuite.Geometries;

namespace Rolla.Models
{
    public class DiggerViewModel
    {
        //برای گرفتن داده ها از دیتابیس و انتقال به کنترلر این ویو مدل طراحی و ساخته شده است
        public Point Origin { get; set; }

        public Point Destination { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; } = true;

        public bool NotFound { get; set; } = true;
    }
}
