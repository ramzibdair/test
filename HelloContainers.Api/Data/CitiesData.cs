using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloContainers.Api.Data
{
    public class CitiesData
    {
        private readonly IConfiguration _config;

        public CitiesData(IConfiguration config)
        {
            _config = config;
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();

            string ConnStr = _config["ConnectionString"];

            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Cities", connection))
                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        City city = new City();
                        city.Name = dr["CityName"].ToString();
                        cities.Add(city);
                    }
                }
            }

            return cities;
        }

    }

    public class City
    {
        public string Name { get; set; }
    }
}
