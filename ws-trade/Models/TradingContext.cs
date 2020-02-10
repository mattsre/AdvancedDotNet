using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class TradingContext : DbContext
    {
        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(Startup._connection);
    }
}