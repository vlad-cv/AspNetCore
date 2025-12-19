using ConfigurationExample.Options;
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

        [Route("/index")]
        public IActionResult Index()
        {
            IConfigurationSection weatherapi = _configuration.GetSection("weatherapi");


            ViewBag.ClientId = weatherapi.GetValue<Guid>("ClientId");
            ViewBag.ClientSecret = weatherapi.GetValue<Guid>("ClientSecret");
            ViewBag.Title = "Index page";
            return View();
        }

        [Route("/home")]
        public IActionResult Home()
        {
            var  weatherApiOptions = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();

            // This is another alternative to Get method 
            // var options = new WeatherApiOptions();
            // _configuration.GetSection("weatherapi").Bind(options);

            ViewBag.Title = "Home page";
            return View("Home",weatherApiOptions);
        }
    }

     
}
