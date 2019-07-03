using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.DAL;
using SessionCart.Web.Models;
using SessionCart.Web.Extensions;

namespace SessionCart.Web.Controllers
{
    public class StoreController : Controller
    {
        /* Steps
          
       */
       
        public ActionResult Index()
        {
            return View();
        }
    }
}