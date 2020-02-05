using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class PricingContext : DbContext
    {
        public DbSet<PricingModel> PricingModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(Startup._connection);
    }
    public class PricingModel
    {
        public int ID { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public double PlanCost { get; set; }
    }
}