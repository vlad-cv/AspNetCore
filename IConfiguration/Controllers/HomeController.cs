using Microsoft.AspNetCore.Mvc;
 

namespace IConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration; 
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            IConfigurationSection weatherapi = _configuration.GetSection("weatherapi");


            ViewBag.ClientId = weatherapi.GetValue<Guid>("ClientId");
            ViewBag.ClientSecret = weatherapi.GetValue<Guid>("ClientSecret");
            return View();
        }
    }

     
}
