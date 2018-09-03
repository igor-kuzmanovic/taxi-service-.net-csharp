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
    public class RideController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("CreateForm");
        }

        public ActionResult CreateForm()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var drivers = db.AppUsers.Where(u => u.Role == UserRole.Driver && !u.IsDriverBusy.Value).ToList();
                    var driverList = drivers.Select(d => new SelectListItem { Text = $"{d.FirstName} {d.LastName}", Value = d.Id.ToString() });
                    ViewBag.DriversList = new SelectList(driverList, "Value", "Text");

                    return View();
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
        }

        public ActionResult Create(RideCreateForm createForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateForm", createForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var newLocation = new Location(createForm);
                    var dbLocation = db.Locations.SingleOrDefault(l => l.Longitude == newLocation.Longitude
                                                                    && l.Latitude == newLocation.Latitude
                                                                    && l.Street == newLocation.Street
                                                                    && l.StreetNumber == newLocation.StreetNumber
                                                                    && l.City == newLocation.City
                                                                    && l.PostalCode == newLocation.PostalCode);
                    var driver = db.AppUsers.SingleOrDefault(u => u.Id == createForm.DriverId);

                    var ride = default(Ride);

                    if (dbLocation != null)
                    {
                        ride = new Ride(dbLocation, dbUser, createForm.VehicleType, driver);
                    }
                    else
                    {
                        ride = new Ride(newLocation, dbUser, createForm.VehicleType, driver);
                    }

                    driver.IsDriverBusy = true;
                    db.Rides.Add(ride);
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}