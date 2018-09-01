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
        private readonly AppDbContext DB { get; } = new AppDbContext();

        public ActionResult Index()
        {
            var user = CheckUser();

            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInForm userForm)
        {
            var user = CheckUser();

            if (!ModelState.IsValid)
            {
                return View(userForm);
            }

            var findUser = DB.AppUsers.SingleOrDefault(u => u.Username == userForm.Username);

            if (findUser == null || findUser.Password != userForm.Password)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(userForm);
            }

            user.Username = userForm.Username;
            user.Password = userForm.Password;
            user.IsLoggedIn = true;

            ViewBag.User = user;
            return View("Home");
        }

        public ActionResult SignOut()
        {
            Session.Abandon();

            var user = new AppUser();
            Session["User"] = user;

            ViewBag.User = user;
            return View("Index");
        }

        private AppUser CheckUser()
        {
            var user = (AppUser)Session["User"];

            if (user == null)
            {
                user = new AppUser();
                Session["User"] = user;
            }

            return user;
        }
    }
}