using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validation.Web.Models;


namespace Validation.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        // GET: User/Register
        // Return the empty registration view
        [HttpGet]
        public IActionResult Register()
        {
            return View("NewUser");
        }

        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the 
        // registration view (if validation fails)     

        [HttpPost]
        public IActionResult RegisterConfirmation(RegistrationViewModel vm)
        {
            return RedirectToAction("RegisterConfirmation");
        }

        // GET: User/Login
        // Return the empty login view

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        // POST: User/Login  
        // Validate the model and redirect to login (if successful) or return the 
        // login view (if validation fails)

        [HttpPost]
        public IActionResult LoginConfirmation(LoginViewModel vm)
        {
            return RedirectToAction("LoginConfirmation");
        }

        // GET: User/Confirmation
        // Return the confirmation view

        [HttpGet]
        public IActionResult UserConfirmation()
        {
            return View();
        }

    }
}