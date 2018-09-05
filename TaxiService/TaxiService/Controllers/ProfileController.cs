using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;
using TaxiService.ViewModels;

namespace TaxiService.Controllers
{
    public class ProfileController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }

            var editForm = new ProfileEditForm(dbUser);

            return View(editForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileEditForm form)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", form);
            }

            var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }

            dbUser.Update(form);
            var updatedUser = new AppUser();
            updatedUser.GetLoginData(dbUser);
            Session["User"] = updatedUser;
            db.SaveChanges();

            return RedirectToAction("Home", "Home");
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