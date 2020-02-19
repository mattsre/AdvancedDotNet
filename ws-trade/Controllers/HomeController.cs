using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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
            var Features = new List<FeatureModel>();
            using (var db = new TradingContext())
            {
                Features = db.Features.ToList();
            }
            return View(new FeatureViewModel(Features));
        }
        public IActionResult Pricing()
        {
            var PricingOptions = new List<PricingModel>();
            using (var db = new TradingContext())
            {
                PricingOptions = db.PricingPlans.OrderBy(p => p.PlanCost).ToList();
            }

            return View(new PricingViewModel(PricingOptions));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
