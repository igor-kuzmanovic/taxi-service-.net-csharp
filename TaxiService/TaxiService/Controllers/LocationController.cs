using System;
using System.Collections.Generic;
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
            return RedirectToAction("EditForm");
        }

        public ActionResult UpdateForm()
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }
                ViewBag.User = user;

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var updateForm = new LocationUpdateForm(dbUser.Location);

                    return View(updateForm);
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
        }

        public ActionResult Update(LocationUpdateForm updateForm)
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }
                ViewBag.User = user;

                if (!ModelState.IsValid)
                {
                    return View("UpdateForm", updateForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var newLocation = new Location(updateForm);
                    var dbLocation = db.Locations.SingleOrDefault(l => l.Equals(newLocation));

                    if (dbLocation != null)
                    {
                        dbUser.UpdateLocation(dbLocation);
                    }
                    else
                    {
                        dbUser.UpdateLocation(newLocation);
                    }

                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}