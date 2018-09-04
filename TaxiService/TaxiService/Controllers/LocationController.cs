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
        public ActionResult Index()
        {
            return RedirectToAction("Update");
        }

        [HttpGet]
        public ActionResult Update()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.Include(u => u.Location).SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var updateForm = new LocationUpdateForm(dbUser.Location);

                    return View(updateForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult Update(LocationUpdateForm updateForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Update", updateForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var location = new Location(updateForm);
                    dbUser.Update(location);
                    var updatedUser = new AppUser();
                    updatedUser.GetLoginData(dbUser);
                    Session["User"] = updatedUser;
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}