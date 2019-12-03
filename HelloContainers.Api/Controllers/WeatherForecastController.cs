using HelloContainers.Api.Data;
using HelloContainers.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloContainers.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly HelloContainersDbContext _dbContext;


        public WeatherForecastController(HelloContainersDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            List<City> cities = await GetCities();

            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                CityName = cities[index - 1].Name
            })
            .ToArray();
        }

        private async Task<List<City>> GetCities()
        {
            return await _dbContext.Cities.ToListAsync();
        }
    }
}
