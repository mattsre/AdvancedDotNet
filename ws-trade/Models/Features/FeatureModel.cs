using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class FeatureModel
    {
        public int ID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }

        public int PricingModelForeignKey { get; set; }
        public PricingModel PricingModel { get; set; }
    }
}