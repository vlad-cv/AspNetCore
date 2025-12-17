using Microsoft.AspNetCore.Mvc;

namespace IConfiguration.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
