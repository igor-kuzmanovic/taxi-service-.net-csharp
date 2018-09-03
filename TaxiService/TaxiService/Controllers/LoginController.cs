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
            return RedirectToAction("SignInForm");
        }

        public ActionResult SignInForm()
        {
            return View();
        }       

        public ActionResult SignIn(SignInForm userForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("SignInForm", userForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Username == userForm.Username && u.Password == userForm.Password);
                if (dbUser != null)
                {
                    var user = new AppUser();
                    user.GetSignedInUserData(dbUser);
                    Session["User"] = user;

                    return RedirectToAction("Home", "Home");
                }

                return RedirectToAction("SignInForm");
            }
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            Session["User"] = null;

            return RedirectToAction("SignInForm");
        }
    }
}