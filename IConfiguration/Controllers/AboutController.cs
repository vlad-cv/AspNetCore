using IConfigurationExample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IConfigurationExample.Controllers
{
    public class AboutController : Controller
    {
        private readonly WeatherApiOptions _weatherApiOptions;

        public AboutController(IOptions<WeatherApiOptions> options)
        {
            _weatherApiOptions = options.Value;
        }

        [Route("/about")]
        public IActionResult Index()
        {
            ViewBag.Title = "About page";

            return View("Home", _weatherApiOptions);
        }
    }
}
