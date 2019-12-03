using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HelloContainers.Api.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HelloContainersDbContext>
    {
        public HelloContainersDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(new DirectoryInfo(Directory.GetCurrentDirectory()).FullName)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables().Build();

            var builder = new DbContextOptionsBuilder<HelloContainersDbContext>();
            var connectionString = configuration["ConnectionString"];
            builder.UseSqlServer(connectionString);
            return new HelloContainersDbContext(builder.Options);
        }
    }
}
