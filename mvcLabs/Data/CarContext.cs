using mvcLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace mvcLabs.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}