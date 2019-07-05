﻿using System;
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
    public class NuclearController : SessionController
    {
        private IWorldDAO _db;

        public NuclearController(IWorldDAO db, IHttpContextAccessor httpContext) : base(httpContext)
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

            return View(vm);
        }

        [HttpGet]
        public IActionResult Codes(string country)
        {
            CodesViewModel vm = new CodesViewModel();
            var countryItem = _db.GetCountry(country);
            vm.CountryName = countryItem.Name;
            vm.LaunchCode = CodeGenerator.GetLaunchCode(vm.CountryName);
            vm.CountryCode = countryItem.Code;

            SetSessionData<CodesViewModel>(vm.LaunchCode, vm);

            return View(vm);
        }

        [HttpGet]
        public IActionResult LaunchPad()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LaunchMissile(LaunchPadViewModel launchPad)
        {
            IActionResult result = null;

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
                        
            return result;
        }

        [HttpGet]
        public IActionResult Explosion()
        {
            ExplosionViewModel vm = GetTempData<ExplosionViewModel>("ExplosionViewModel");
            return View("Explosion", vm);
        }

        [HttpGet]
        public IActionResult Targets()
        {
            var countries = _db.GetCountries();
            return View(countries);
        }

    }
}