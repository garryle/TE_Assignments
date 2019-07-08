using Lecture.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.DAL
{
    public interface IWorldDAO
    {
        List<City> GetCities(string countryCode);
        List<City> GetCities(string countryCode, string district);
        List<Country> GetCountries(string sortCol = "name");
        Country GetCountry(string code);
        List<string> WorldColNames { get; }
        bool UpdateCountryPopulation(string code, int population);
    }
}
