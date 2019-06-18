using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class WorldDAO : IWorldDAO
    {
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";
        private string _connectionString = "";

        public WorldDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region City

        public int AddCity(City city)
        {
            // Build the SQL string
            const string sql = "INSERT City (Name, District, CountryCode, Population) " +
                               "VALUES (@Name, @District, @CountryCode, @Population);";

            // Connect to the database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Parameretize query
                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Name", city.Name);
                cmd.Parameters.AddWithValue("@District", city.District);
                cmd.Parameters.AddWithValue("@CountryCode", city.CountryCode);
                cmd.Parameters.AddWithValue("@Population", city.Population);

                // Execute SQL command
                city.CityId = (int)cmd.ExecuteScalar();
            }

            return city.CityId;
        }        

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> result = new List<City>();

            const string sql = "SELECT * FROM City Where countrycode = @CountryCode;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CountryCode", countryCode);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(GetCityFromReader(reader));
                }
            }

            return result;
        }

        private City GetCityFromReader(SqlDataReader reader)
        {
            City item = new City();

            item.CityId = Convert.ToInt32(reader["id"]);
            item.CountryCode = Convert.ToString(reader["countrycode"]);
            item.District = Convert.ToString(reader["district"]);
            item.Name = Convert.ToString(reader["name"]);
            item.Population = Convert.ToInt32(reader["population"]);

            return item;
        }

        #endregion

        #region Country

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
                    countries.Add(ConvertReaderToCountry(reader));
                }
            }

            // Return the output
            return countries;
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

        public string AddCountry(Country item)
        {
            // Create a connection
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO countrylanguage (code, " +
                                                                "name, " +
                                                                "continent, " +
                                                                "region, " +
                                                                "surfacearea, " +
                                                                "population, " +
                                                                "code2, " +
                                                                "localname, " +
                                                                "governmentform) " +
                                   "VALUES (@code, " +
                                           "@name, " +
                                           "@continent, " +
                                           "@region, " +
                                           "@surfacearea, " +
                                           "@population, " +
                                           "@code2, " +
                                           "@localname, " +
                                           "@governmentform);";

                // Open the connection
                conn.Open();

                // Create the command
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

                // Execute the command
                cmd.ExecuteNonQuery();
            }

            return item.Code;
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

        #endregion

        #region Language

        public IList<Language> GetLanguages(string countryCode)
        {
            List<Language> languages = new List<Language>();

            const string sql = "SELECT * FROM countrylanguage WHERE countrycode = @countrycode;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@countrycode", countryCode);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    languages.Add(ConvertReaderToLanguage(reader));
                }
            }

            return languages;
        }

        public string AddNewLanguage(Language newLanguage)
        {
            // Create a connection
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO countrylanguage (countrycode, language, isofficial, percentage) " +
                                   "VALUES (@countrycode, @language, @isofficial, @percentage);";

                // Open the connection
                conn.Open();

                // Create the command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@countrycode", newLanguage.CountryCode);
                cmd.Parameters.AddWithValue("@language", newLanguage.Name);
                cmd.Parameters.AddWithValue("@isofficial", newLanguage.IsOfficial);
                cmd.Parameters.AddWithValue("@percentage", newLanguage.Percentage);

                // Execute the command
                cmd.ExecuteNonQuery();
            }

            return newLanguage.CountryCode;
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            const string sql = "DELETE FROM countrylanguage " +
                               "WHERE countrycode = @countrycode and language = @language";

            bool result = false;

            // Create a connection
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create the command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@countrycode", deadLanguage.CountryCode);
                cmd.Parameters.AddWithValue("@language", deadLanguage.Name);

                // Execute the command
                result = cmd.ExecuteNonQuery() == 1;
            }

            return result;
        }

        private Language ConvertReaderToLanguage(SqlDataReader reader)
        {
            Language result = new Language();

            result.CountryCode = Convert.ToString(reader["countrycode"]);
            result.Name = Convert.ToString(reader["language"]);
            result.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
            result.Percentage = Convert.ToInt32(reader["percentage"]);

            return result;
        }

        #endregion
    }
}
