using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class WhiteOakController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Test"] = "Hi I'm a view data";
            ViewBag.Test = "Hi I'm a view bag";

            return View();
        }

        public IActionResult SaySomething(string message, int times)
        {
            ViewBag.Message = message;
            ViewBag.Times = times;
            return View();
        }
    }
}