using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;
using TaxiService.ViewModels;

namespace TaxiService.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }       

        [HttpPost]
        public ActionResult SignIn(SignInForm userForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("SignIn", userForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Username == userForm.Username && u.Password == userForm.Password);
                if (dbUser != null)
                {
                    var user = new AppUser();
                    user.GetLoginData(dbUser);
                    Session["User"] = user;

                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("SignIn");
            }
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session["User"] = null;

            return RedirectToAction("SignIn");
        }
    }
}