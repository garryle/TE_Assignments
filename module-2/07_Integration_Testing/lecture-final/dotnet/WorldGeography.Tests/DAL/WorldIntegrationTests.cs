using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests.DAL
{
    [TestClass()]
    public class WorldIntegrationTests
    {
        private const string TEST_COUNTRY_CODE = "ZZZ";
        private TransactionScope _tran = null;
        private string _countryId = "";
        private IWorldDAO _db = null;

        
        [TestInitialize]
        public void Initialize()
        {
            _db = new WorldDAO("Data Source=localhost\\sqlexpress;Initial Catalog=World;Integrated Security=True");
            _tran = new TransactionScope();

            Country item = new Country()
            {
                Code = TEST_COUNTRY_CODE,
                Name = "Sleepy",
                Continent = "Asia",
                Region = "Middle East",
                SurfaceArea = 0.1,
                Population = 1,
                Code2 = null,
                LocalName = "Bob",
                GovernmentForm = "Histocracy"
            };
            _countryId = _db.AddCountry(item);

        }

        [TestCleanup]
        public void Cleanup()
        {
            _tran.Dispose();
            _countryId = "";
        }

        [TestMethod()]
        public void TestCountry()
        {
            
        }

        [TestMethod()]
        public void TestCity()
        {
            // Test add city
            City item = new City()
            {
                Name = "SleepyVille",
                Population = 1,
                CountryCode = _countryId,
                District = "Bed"
            };
            var cityId = _db.AddCity(item);

            // Test get cities by country code
            var cities = _db.GetCitiesByCountryCode(TEST_COUNTRY_CODE);
            Assert.AreEqual(1, cities.Count, "City was not added.");

            var city = cities[0];
            Assert.AreEqual(item.Name, city.Name, "City name did not match.");
            Assert.AreEqual(item.Population, city.Population, "Population did not match.");
            Assert.AreEqual(item.CountryCode, city.CountryCode, "CountryCode did not match.");
            Assert.AreEqual(item.District, city.District, "District did not match.");
        }

        [TestMethod()]
        public void TestLanguage()
        {

        }
    }
}
