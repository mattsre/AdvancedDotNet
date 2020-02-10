using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class PricingModel
    {
        public int ID { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public double PlanCost { get; set; }
    }
}