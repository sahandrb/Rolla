using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rolla.Models;

namespace Rolla.Controllers
{
    // ������ ����? ǁ�?�?�� ���? ��?�?� ����� ���?� ��?� ����? � �����
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // ���?� �ǐ� ���? ��� ��?����ǡ ����� � ������� ����? ������
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /
        // ���?� ���� ���? ��?� ?� ������� ����?
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Privacy
        // ���?� ���� �?��ʝ��? ��?� ����? (Privacy Policy)
        public IActionResult Privacy()
        {
            return View();
        }

        // ��?�?� ����� �� ������ � ���?� ���?�� �������
        // ResponseCache �?����� ��� �� �?� ��? ���? �?� ���� ���� �?��
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // ���?� ��� ��� �� ����� ������� ���? ?� ����� ����᝘���� (TraceIdentifier)
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
