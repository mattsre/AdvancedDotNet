using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcLabs.Models;
using System.Globalization;

namespace mvcLabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            ViewBag.Cultures = cultures;
            return View();
        }

        public IActionResult Contact()
        {
            var viewModel = new CultureViewModel(CultureInfo.GetCultures(CultureTypes.SpecificCultures));
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
