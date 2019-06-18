using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string _connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            _connectionString = databaseConnectionString;
        }

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

        private Language ConvertReaderToLanguage(SqlDataReader reader)
        {
            Language result = new Language();

            result.CountryCode = Convert.ToString(reader["countrycode"]);
            result.Name = Convert.ToString(reader["language"]);
            result.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
            result.Percentage = Convert.ToInt32(reader["percentage"]);

            return result;
        }

        public string AddNewLanguage(Language newLanguage)
        {
            // Create a connection
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create the command
                SqlCommand cmd = new SqlCommand("INSERT INTO countrylanguage VALUES (@countrycode, @language, @isofficial, @percentage);", conn);
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
            bool result = false;

            // Create a connection
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create the command
                SqlCommand cmd = new SqlCommand("DELETE FROM countrylanguage WHERE countrycode = @countrycode and language = @language", conn);
                cmd.Parameters.AddWithValue("@countrycode", deadLanguage.CountryCode);
                cmd.Parameters.AddWithValue("@language", deadLanguage.Name);

                // Execute the command
                result = cmd.ExecuteNonQuery() == 1;
            }

            return result;
        }
    }
}
