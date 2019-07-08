using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Web.DAL;
using Post.Web.Models;

namespace Post.Web.Controllers
{
    public class HomeController : Controller
    {

        private IReviewDAO _db;

        public HomeController(IReviewDAO db)
        {
            _db = db;
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Review> reviews = _db.GetAllReviews();
            return View(reviews);
        }

        [HttpGet]
        public ActionResult GetNewReview()
        {
            Review vm = new Review();
            return View(vm);
        }

        [HttpPost]
        public ActionResult PostReview(Review model)
        {
            int success = _db.SaveReview(model);

            if (success != 1)
            {
                TempData["error"] = "unable to post review, try again";
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
