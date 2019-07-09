using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.DAL;
using Lecture.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.DAO;
using SessionControllerData;

namespace Lecture.Web.Controllers
{
    public class NuclearController : AuthenticationController
    {
        private IWorldDAO _db;

        public NuclearController(IUserSecurityDAO userDb, IWorldDAO db, IHttpContextAccessor httpContext) : base(userDb, httpContext)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PresidentialViewModel vm = new PresidentialViewModel();
            var countries = _db.GetCountries();
            foreach (var country in countries)
            {
                vm.Countries.Add(new SelectListItem(country.Name, country.Code));
            }

            string errorMessage = GetTempData<string>("Error");
            if(errorMessage != null)
            {
                vm.ErrorMessage = errorMessage;
            }

            return GetAuthenticatedView("Index", vm);
        }

        [HttpGet]
        public IActionResult Codes(string country)
        {
            IActionResult result = null;

            var userMgr = GetUserManager();
            if (userMgr.IsAuthenticated)
            {
                CodesViewModel vm = new CodesViewModel();
                var countryItem = _db.GetCountry(country);
                vm.CountryName = countryItem.Name;
                vm.LaunchCode = CodeGenerator.GetLaunchCode(vm.CountryName);
                vm.CountryCode = countryItem.Code;

                SetSessionData<CodesViewModel>(vm.LaunchCode, vm);

                result = View("Codes", vm);
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }

            return result;
        }

        [HttpGet]
        public IActionResult LaunchPad()
        {
            string viewName = "";

            var areWeGood = GetSessionData<bool>("Identify");
            if(!areWeGood)
            {
                viewName = "Identify";
            }
            else
            {
                viewName = "LaunchPad";
            }

            return GetAuthenticatedView(viewName);
        }

        [HttpPost]
        public IActionResult LaunchMissile(LaunchPadViewModel launchPad)
        {
            IActionResult result = null;

            var userMgr = GetUserManager();
            if (userMgr.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    // Return the new view again
                    result = View("LaunchPad", launchPad);
                }
                else
                {
                    if (launchPad != null && launchPad.LaunchCode != null)
                    {
                        CodesViewModel codesViewModel = GetSessionData<CodesViewModel>(launchPad.LaunchCode);
                        if (codesViewModel == null)
                        {
                            result = View("SelfDestruct");
                        }
                        else
                        {
                            var country = _db.GetCountry(codesViewModel.CountryCode);
                            int newPop = (int)(country.Population * 0.9);
                            _db.UpdateCountryPopulation(country.Code, newPop);

                            ExplosionViewModel vm = new ExplosionViewModel();
                            vm.CountryName = country.Name;
                            vm.OldPop = country.Population;
                            vm.NewPop = newPop;

                            SetTempData<ExplosionViewModel>("ExplosionViewModel", vm);
                            result = RedirectToAction("Explosion");
                        }
                    }
                    else
                    {
                        SetTempData<string>("Error", "You must get a code first.");
                        // Tell user to get a launch code first
                        result = RedirectToAction("Index");
                    }
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
                        
            return result;
        }

        [HttpGet]
        public IActionResult Explosion()
        {
            ExplosionViewModel vm = GetTempData<ExplosionViewModel>("ExplosionViewModel");
            return GetAuthenticatedView("Explosion", vm);
        }

        [HttpGet]
        public IActionResult Targets()
        {
            var countries = _db.GetCountries();
            return GetAuthenticatedView("Targets", countries);
        }

        [HttpGet]
        public IActionResult Identify()
        {
            return GetAuthenticatedView("Identify");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Identify(IdentifyViewModel vm)
        {
            IActionResult result = null;

            var userMgr = GetUserManager();
            if (userMgr.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    SetSessionData("Identify", false);

                    ModelState.AddModelError("identification", "Please identify yourself");

                    // Return the new view again
                    result = View();
                }
                else
                {
                    SetSessionData("Identify", true);
                    result = RedirectToAction("LaunchPad");
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }

            return result;
        }

    }
}