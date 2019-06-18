using System;
using System.Collections.Generic;
using System.Text;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public interface IWorldDAO
    {
        #region City

        /// <summary>
        /// Gets all cities provided a country code.
        /// </summary>
        /// <param name="countryCode">The country code to search for.</param>
        /// <returns></returns>
        IList<City> GetCitiesByCountryCode(string countryCode);

        /// <summary>
        /// Adds a new city.
        /// </summary>
        /// <param name="city">The city to add.</param>
        int AddCity(City city);

        #endregion

        #region Country
        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns></returns>
        IList<Country> GetCountries();

        /// <summary>
        /// Gets all countries for a continent.
        /// </summary>
        /// <param name="continent">The continent to filter by.</param>
        /// <returns></returns>
        IList<Country> GetCountries(string continent);

        string AddCountry(Country item);

        /// <summary>
        /// Updates the country record
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns>True if successfully updated</returns>
        bool UpdateCountry(Country item);

        #endregion

        #region Language

        /// <summary>
        /// Gets all languages for a given country.
        /// </summary>
        /// <param name="countryCode">The country code to filter by.</param>
        /// <returns></returns>
        IList<Language> GetLanguages(string countryCode);

        /// <summary>
        /// Inserts a new language.
        /// </summary>
        /// <param name="newLanguage"></param>
        /// <returns></returns>
        string AddNewLanguage(Language newLanguage);

        /// <summary>
        /// Removes an existing language.
        /// </summary>
        /// <param name="deadLanguage"></param>
        /// <returns></returns>
        bool RemoveLanguage(Language deadLanguage);

        #endregion
    }
}
