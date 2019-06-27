using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BriAge(Film film)
        {
            //Dictionary<string, object> myList = new Dictionary<string, object>();
            //foreach(var item in myList)
            //{

            //}
            
            //ViewData["Lee"] = film;
            //ViewBag.Lee = film;

            //var test = ViewBag.Lee;
            //var testy = ViewData["Lee"];
            //Film testyFilm = testy as Film;
            //if(test != null)
            //{
            //    var image = test.ImageUrl;
            //}

            return View();
        }
    }
}