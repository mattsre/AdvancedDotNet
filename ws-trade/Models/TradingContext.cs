using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class TradingContext : DbContext
    {
        public DbSet<PricingModel> PricingPlans { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<FeatureModel> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("wsTrade");
            modelBuilder.Entity<FeatureModel>()
                .HasOne(f => f.PricingModel)
                .WithMany(p => p.SupportedFeatures)
                .HasForeignKey(f => f.PricingModelForeignKey);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(Startup._connection, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "wsTrade"));
    }
}