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
            return RedirectToAction("UpdateForm");
        }

        public ActionResult Select()
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

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var locations = db.Locations.ToList();

                    return View(locations);
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
        }

        public ActionResult UpdateForm()
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

                var dbUser = db.AppUsers.Include(u => u.Location).SingleOrDefault(u => u.Id == user.Id);
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
                var user = (AppUser)Session["User"];
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
                    var dbLocation = db.Locations.SingleOrDefault(l => l.Longitude == newLocation.Longitude
                                                                    && l.Latitude == newLocation.Latitude
                                                                    && l.Street == newLocation.Street
                                                                    && l.StreetNumber == newLocation.StreetNumber
                                                                    && l.City == newLocation.City
                                                                    && l.PostalCode == newLocation.PostalCode);

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

        public ActionResult UpdateSelect(int id)
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

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var dbLocation = db.Locations.SingleOrDefault(l => l.Id == id);

                    if (dbLocation != null)
                    {
                        dbUser.UpdateLocation(dbLocation);
                        db.SaveChanges();
                    }                  
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}