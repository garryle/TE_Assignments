using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IActionResult html = View();
            return html;
        }

        public IActionResult Duh()
        {
            return View();
        }
    }
}