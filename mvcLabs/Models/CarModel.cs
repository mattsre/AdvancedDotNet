using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mvcLabs.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(Startup._connection);
    }
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public double MaxSpeed { get; set; }
    }
}