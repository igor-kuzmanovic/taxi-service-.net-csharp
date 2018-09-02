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
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                user = new AppUser();
                Session["User"] = user;
            }
            ViewBag.User = user;

            return View();
        }       

        public ActionResult SignIn(SignInForm userForm)
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }
                ViewBag.User = user;

                if (!ModelState.IsValid)
                {
                    return View("SignInForm", userForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Username == userForm.Username && u.Password == userForm.Password);
                if (dbUser != null)
                {
                    user.GetSignedInUserData(dbUser);

                    return RedirectToAction("Home", "Home");
                }
                else
                {                   
                    return RedirectToAction("SignInForm");
                }
            }
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            AppUser user = new AppUser();
            Session["User"] = user;
            ViewBag.User = user;

            return RedirectToAction("SignInForm");
        }
    }
}