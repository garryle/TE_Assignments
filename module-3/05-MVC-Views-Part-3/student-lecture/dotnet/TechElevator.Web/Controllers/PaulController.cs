using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class PaulController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("paul")]
        public IActionResult PlaysBandGames(string link)
        {
            return View("PlaysBandGames", link);
        }

        public IActionResult ChrisPlaysVideoGames(string link)
        {
            return View("Chris", link);
        }

        public IActionResult LeePlaysGuildWarsToo(string link)
        {
            return View("Lee", link);
        }

        // /lee?link=url
    }
}