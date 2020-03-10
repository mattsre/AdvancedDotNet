using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mvcLabs.Models
{
  public class CarContext : DbContext
  {
    public DbSet<Car> Cars { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("mvcLabs");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(Startup._connection, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mvcLabs"));
  }
  public class Car
  {
    public int ID { get; set; }
    [Required]
    public string Model { get; set; }
    [Range(5, 300)]
    public double MaxSpeed { get; set; }
    public string ImageLink { get; set; }
    public int? ManufacturerID { get; set; }

    public virtual Manufacturer Manufacturer { get; set; }
  }
}