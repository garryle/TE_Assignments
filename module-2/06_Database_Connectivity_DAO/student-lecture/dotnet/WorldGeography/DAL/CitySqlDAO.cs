using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";
        private string _connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            _connectionString = databaseconnectionString;
        }

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

        public City GetCityById(int id)
        {
            City result = null;

            const string sql = "SELECT * FROM City Where id = @id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = GetCityFromReader(reader);
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

    }
}
