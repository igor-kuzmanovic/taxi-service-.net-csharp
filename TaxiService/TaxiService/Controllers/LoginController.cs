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
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            var user = (AppUser)Session["User"];
            if (user != null)
            {
                return RedirectToAction("Home", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInForm form)
        {
            var user = (AppUser)Session["User"];
            if (user != null)
            {
                return RedirectToAction("Home", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View("SignIn", form);
            }

            var dbUser = db.AppUsers.SingleOrDefault(u => u.Username == form.Username && u.Password == form.Password);
            if (dbUser == null)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View("SignIn", form);
            }

            var loginUser = new AppUser();
            loginUser.GetLoginData(dbUser);
            Session["User"] = loginUser;

            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn");
            }

            Session.Abandon();
            Session["User"] = null;

            return RedirectToAction("SignIn");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}