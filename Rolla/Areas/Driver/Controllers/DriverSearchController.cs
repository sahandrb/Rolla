using Microsoft.AspNetCore.Mvc;

namespace Rolla.Areas.Driver.Controllers
{
    [Area("Driver")]
    public class DriverSearchController : Controller
    {
        [HttpPost]
        public IActionResult AcceptMethod(double originLat, double originLon, double destLat, double destLon)
        {
            // محاسبه فاصله به متر
            double distanceMeters = CalculateDistance(originLat, originLon, destLat, destLon);

            // محاسبه قیمت (مثال: هر کیلومتر × 10000 + 20000)
            double cost = (distanceMeters / 1000) * 10000 + 20000;

            // برگرداندن نتیجه
            return Ok(new
            {
                DistanceMeters = distanceMeters,
                Cost = cost
            });
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371000; // شعاع زمین به متر
            var latRad1 = lat1 * Math.PI / 180;
            var latRad2 = lat2 * Math.PI / 180;
            var deltaLat = (lat2 - lat1) * Math.PI / 180;
            var deltaLon = (lon2 - lon1) * Math.PI / 180;

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(latRad1) * Math.Cos(latRad2) *
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // فاصله به متر
        }

        public IActionResult SearchMethod()
        {
            return View();
        }
    }
}
