using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string _connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            _connectionString = databaseconnectionString;
        }

        public IList<Country> GetCountries()
        {
            // Declare the output variable
            List<Country> countries = new List<Country>();

            const string sql = "SELECT * FROM country;";
            
            // Create a connection to the database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command to send to the database
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Execute the command
                SqlDataReader reader = cmd.ExecuteReader();

                // Read each row
                while (reader.Read())
                {
                    Country ctry = ConvertReaderToCountry(reader);
                    countries.Add(ctry);
                }
            }

            // Return the output
            return countries;
        }

        private Country ConvertReaderToCountry(SqlDataReader reader)
        {
            Country ctry = new Country();

            ctry.Code = Convert.ToString(reader["code"]);
            ctry.Name = Convert.ToString(reader["name"]);
            ctry.Continent = Convert.ToString(reader["continent"]);
            ctry.Region = Convert.ToString(reader["region"]);
            ctry.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            ctry.Population = Convert.ToInt32(reader["population"]);
            ctry.GovernmentForm = Convert.ToString(reader["governmentform"]);
            ctry.Code2 = Convert.ToString(reader["code2"]);
            ctry.LocalName = Convert.ToString(reader["localname"]);

            return ctry;
        }

        public IList<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            const string sql = "SELECT * FROM country WHERE continent = @continent;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@continent", continent);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Country ctry = ConvertReaderToCountry(reader);
                    countries.Add(ctry);
                }
            }

            return countries;
        }

        public bool UpdateCountry(Country item)
        {
            bool isSuccessful = false;

            const string sql = "UPDATE country SET code = @code, " +
                                                  "name = @name, " +
                                                  "continent = @continent, " +
                                                  "region = @region, " +
                                                  "surfacearea = @surfacearea, " +
                                                  "population = @population, " +
                                                  "code2 = @code2, " +
                                                  "localname = @localname, " +
                                                  "governmentform = @governmentform " +
                                                  "WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@code", item.Code);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@continent", item.Continent);
                cmd.Parameters.AddWithValue("@region", item.Region);
                cmd.Parameters.AddWithValue("@surfacearea", item.SurfaceArea);
                cmd.Parameters.AddWithValue("@population", item.Population);
                cmd.Parameters.AddWithValue("@code2", item.Code2);
                cmd.Parameters.AddWithValue("@localname", item.LocalName);
                cmd.Parameters.AddWithValue("@governmentform", item.GovernmentForm);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }
    }
}
