using Lecture.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.DAL
{
    public class WorldDAO : IWorldDAO
    {
        private string _connectionString;

        public List<string> WorldColNames { get; } = new List<string>();

        public WorldDAO(string connectionString)
        {
            _connectionString = connectionString;

            WorldColNames.Add("code");
            WorldColNames.Add("name");
            WorldColNames.Add("continent");
            WorldColNames.Add("headofstate");
        }

        public List<Country> GetCountries(string sortCol)
        {
            if(!WorldColNames.Contains(sortCol))
            {
                throw new Exception("Not a valid column name for the country table.");
            }

            List<Country> countries = new List<Country>();

            string sql = $"SELECT * FROM country Order By {sortCol};";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Country country = new Country()
                    {
                        Code = Convert.ToString(reader["code"]),
                        Name = Convert.ToString(reader["name"]),
                        Continent = Convert.ToString(reader["continent"]),
                        HeadOfState = Convert.ToString(reader["headofstate"])
                    };
                    countries.Add(country);
                }
            }

            return countries;
        }
        public List<City> GetCities(string countryCode)
        {
            List<City> cities = new List<City>();
                        
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode=@countryCode", conn);
                cmd.Parameters.AddWithValue("@countryCode", countryCode);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var city = new City()
                    {
                        CityId = Convert.ToInt32(reader["id"]),
                        Name = Convert.ToString(reader["name"]),
                        CountryCode = Convert.ToString(reader["countrycode"]),
                        District = Convert.ToString(reader["district"]),
                        Population = Convert.ToInt32(reader["population"])
                    };

                    cities.Add(city);
                }
            }

            return cities;
        }
        public List<City> GetCities(string countryCode, string district)
        {
            district = "%" + district + "%";

            var output = new List<City>();

            // Create a new connection object
            using (var conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                var sql = $"SELECT * FROM city WHERE countryCode = @countryCode AND district LIKE @district";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@countryCode", countryCode);
                cmd.Parameters.AddWithValue("@district", district);

                // Execute the command
                var reader = cmd.ExecuteReader();

                // Loop through each row
                while (reader.Read())
                {
                    // Create a city
                    var city = new City();
                    city.CityId = Convert.ToInt32(reader["id"]);
                    city.Name = Convert.ToString(reader["name"]);
                    city.CountryCode = Convert.ToString(reader["countrycode"]);
                    city.District = Convert.ToString(reader["district"]);
                    city.Population = Convert.ToInt32(reader["population"]);

                    output.Add(city);
                }
            }

            return output;
        }

        public Country GetCountry(string code)
        {
            Country country = null;

            const string sql = "SELECT * FROM country Where code = @code;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("code", code);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    country = new Country()
                    {
                        Code = Convert.ToString(reader["code"]),
                        Name = Convert.ToString(reader["name"]),
                        Continent = Convert.ToString(reader["continent"]),
                        HeadOfState = Convert.ToString(reader["headofstate"])
                    };
                }
            }

            return country;
        }
    }
}
