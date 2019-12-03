using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloContainers.Api.Models;

namespace HelloContainers.Api.Data
{
    public class HelloContainersDbContextSeed
    {
        public async Task SeedAsync(HelloContainersDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(GetSampleCities());

                await context.SaveChangesAsync();
            }
        }

        private List<City> GetSampleCities()
        {
            List<City> cities = new List<City>();

            cities.Add(new City { Name = "Riyadh" });
            cities.Add(new City { Name = "Jeddah" });
            cities.Add(new City { Name = "Dammam" });

            return cities;

        }
    }
}
