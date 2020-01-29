using MVCLab1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCLab1
{
    public class PricingViewModel
    {

        public PricingViewModel(List<PricingModel> pricing)
        {
            PricingOptionsDropDown = pricing.Select(o => new SelectListItem()
            {
                Text = o.PlanName
            });

            PricingOptions = pricing;
        }
        public IEnumerable<SelectListItem> PricingOptionsDropDown { get; set; }
        public List<PricingModel> PricingOptions { get; set; }
    }
}