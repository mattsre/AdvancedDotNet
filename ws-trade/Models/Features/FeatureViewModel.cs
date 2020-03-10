using MVCLab1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCLab1.Models
{
    public class FeatureViewModel
    {

        public FeatureViewModel(List<FeatureModel> features)
        {
            Features = features;
        }
        public List<FeatureModel> Features { get; set; }
    }
}