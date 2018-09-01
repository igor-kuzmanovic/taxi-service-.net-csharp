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
            AppUser user = (AppUser)Session["User"];
            if (user == null)
            {
                user = new AppUser();
                Session["User"] = user;
            }

            ViewBag.User = user;
            return View();
        }

        public ActionResult SignUpForm()
        {
            AppUser user = (AppUser)Session["User"];
            if (user == null)
            {
                user = new AppUser();
                Session["User"] = user;
            }

            ViewBag.User = user;
            return View();
        }

        public ActionResult SignUp(SignUpForm userForm)
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }

                var newUser = new AppUser() { Username = userForm.Username, Password = userForm.Password };
                var dbUser = db.AppUsers.Add(newUser);
                db.SaveChanges();

                ViewBag.User = user;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignIn(SignInForm userForm)
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Username == userForm.Username && u.Password == userForm.Password);
                if (dbUser != null)
                {
                    user.Id = dbUser.Id;
                    user.Username = userForm.Username;
                    user.IsLoggedIn = true;
                }
                else
                {
                    ViewBag.User = user;
                    return RedirectToAction("Index");
                }

                ViewBag.User = user;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SignOut()
        {
            Session.Abandon();

            AppUser user = new AppUser();
            Session["User"] = user;

            ViewBag.User = user;
            return RedirectToAction("Index");
        }
    }
}