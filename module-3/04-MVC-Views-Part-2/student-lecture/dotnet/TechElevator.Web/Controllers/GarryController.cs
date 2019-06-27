using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class GarryController : Controller
    {
        public IActionResult Index()
        {
            return View("Luna");
        }

        //[Route("film")]
        public IActionResult Detail(Film film)
        {
            ComposerViewModel vm = new ComposerViewModel();
            vm.Film = film;
            vm.Music.ScottyTime = "Hell Yah";
            return View(vm);
        }
    }
}
