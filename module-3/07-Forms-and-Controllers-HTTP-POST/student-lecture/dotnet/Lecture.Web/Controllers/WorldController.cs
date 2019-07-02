using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.DAL;
using Lecture.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SessionControllerData;

namespace Lecture.Web.Controllers
{
    public class WorldController : SessionController
    {
        private IWorldDAO _db;

        public WorldController(IWorldDAO db, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PresidentialViewModel vm = new PresidentialViewModel();
            var countries = _db.GetCountries();
            foreach(var country in countries)
            {
                vm.Countries.Add(new SelectListItem(country.Name, country.Code));
            }
            
            return View(vm);
        }

        [HttpGet]
        [Route("World/PresidentialDetail")]
        public IActionResult Results(string country)
        {
            var countryItem = _db.GetCountry(country);

            return View("PresidentialDetail", countryItem.HeadOfState);
        }

        [HttpGet]
        [Route("country")]
        public IActionResult AddCountry()
        {
            var countries = GetSessionData<List<string>>("Countries");
            if (countries == null)
            {
                countries = new List<string>();
            }
            AddCountryViewModel vm = new AddCountryViewModel();
            vm.ExistingCountries = countries;
            return View(vm);
        }

        // On a post make sure you create a new view model class to map the incoming parameters to or
        // things may not bind as expected.
        [HttpPost]
        public IActionResult AddCountry(AddCountryViewModel countryViewModel)
        {
            SetTempData<AddCountryViewModel>("CountryName", countryViewModel);

            var countries = GetSessionData<List<string>>("Countries");
            if (countries == null)
            {
                countries = new List<string>();                
            }
            countries.Add(countryViewModel.Name);
            SetSessionData<List<string>>("Countries", countries);
            
            //return RedirectToAction("Success", new { Name = countryViewModel.Name });
            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Success()
        {
            var countryViewModel = GetTempData<AddCountryViewModel>("CountryName");
            return View(countryViewModel);
        }

        [HttpGet]
        public IActionResult CountryTime()
        {
            return View(GetWorldColNames());
        }

        [HttpGet]
        public IActionResult CountryTimeResults(string sortColumn)
        {
            CountryTimeResultsViewModel vm = new CountryTimeResultsViewModel();
            vm.Columns = GetWorldColNames();
            vm.Countries = _db.GetCountries(sortColumn);

            return View(vm);
        }

        private List<SelectListItem> GetWorldColNames()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            var colNames = _db.WorldColNames;
            foreach (var name in colNames)
            {
                result.Add(new SelectListItem(name, name));
            }
            return result;
        }

    }
}