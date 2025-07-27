using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rolla.Models;

namespace Rolla.Controllers
{
    // ò‰ —·— ⁄„Ê„? «Å·?ò?‘‰ »—«? „œ?—?  ’›Õ«  «’·?° Õ—?„ Œ’Ê’? Ê Œÿ«Â«
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //  “—?ﬁ ·«ê— »—«? À»  —Ê?œ«œÂ«° Œÿ«Â« Ê «ÿ·«⁄«  «Ã—«? »—‰«„Â
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /
        // ‰„«?‘ ’›ÕÂ «’·? ”«?  ?« œ«‘»Ê—œ ⁄„Ê„?
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Privacy
        // ‰„«?‘ ’›ÕÂ ”?«” ùÂ«? Õ—?„ Œ’Ê’? (Privacy Policy)
        public IActionResult Privacy()
        {
            return View();
        }

        // „œ?—?  Œÿ«Â« œ— »—‰«„Â Ê ‰„«?‘ Ã“∆?«  œ—ŒÊ«” 
        // ResponseCache €?—›⁄«· ‘œÂ  « Â?ç ò‘? »—«? «?‰ ’›ÕÂ ’Ê—  ‰ê?—Â
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //  Ê·?œ „œ· Œÿ« »« ‘„«—Â œ—ŒÊ«”  ›⁄·? ?« ‘‰«”Â œ‰»«·ùò‰‰œÂ (TraceIdentifier)
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
