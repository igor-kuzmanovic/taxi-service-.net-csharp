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
    public class LocationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Update");
        }

        [HttpGet]
        public ActionResult Update()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            var dbUser = db.AppUsers.Include(u => u.Location).SingleOrDefault(u => u.Id == user.Id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }

            var updateForm = new LocationUpdateForm(dbUser.Location);

            return View(updateForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LocationUpdateForm form)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            if (!ModelState.IsValid)
            {
                return View("Update", form);
            }

            var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }

            var location = new Location(form);
            dbUser.Update(location);
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