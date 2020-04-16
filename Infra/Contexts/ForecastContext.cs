using Forecast.Domain.Entities.Enroll;
using Microsoft.EntityFrameworkCore;

namespace Forecast.Infra
{

    public class ForecastContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        
        public ForecastContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; user id = postgres; password = x8qchd7pth; database = Forecast2");
        }

    }
}
