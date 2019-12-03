using HelloContainers.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloContainers.Api.Data
{
    public class HelloContainersDbContext : DbContext
    {
        public HelloContainersDbContext(DbContextOptions<HelloContainersDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
