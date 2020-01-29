using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MVCLab1.Models;

namespace MVCLab1.Controllers
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

        public IActionResult Features()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            var PricingOptions = new List<PricingModel>();
            PricingOptions.Add(new PricingModel
            {
                PlanName = "Basic",
                PlanDescription = "Testing123",
                PlanCost = 14.99,
            });

            PricingOptions.Add(new PricingModel
            {
                PlanName = "Startup",
                PlanDescription = "Testing123",
                PlanCost = 99.99,
            });

            PricingOptions.Add(new PricingModel
            {
                PlanName = "Enteprise",
                PlanDescription = "Testing123",
                PlanCost = 199.99,
            });

            return View(new PricingViewModel(PricingOptions));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
