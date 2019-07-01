using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Web.Models;
using Forms.Web.DAL;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICityDAO _dao = null;

        public HomeController(ICityDAO dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Represents an index action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            CitySearchViewModel vm = new CitySearchViewModel();

            var cities = _dao.GetCities();
            foreach(var city in cities)
            {
                vm.Cities.Add(new SelectListItem(city.Name, city.District));
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Search(SearchResultsViewModel vm)
        {
            List<string> cityNames = new List<string>();
            var cities = _dao.GetCities();
            foreach(var city in cities)
            {
                if(city.District == vm.City)
                {
                    cityNames.Add(city.Name);
                }
            }
            return View("SearchResults", cityNames);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
