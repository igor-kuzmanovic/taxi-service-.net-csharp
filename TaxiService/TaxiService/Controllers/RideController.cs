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

                return RedirectToAction("Home", "Home");
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

        public ActionResult ProcessForm()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var dbRide = db.Rides.Include(r => r.Source).Include(r => r.Dispatcher).FirstOrDefault(r => r.Driver.Id == dbUser.Id && r.Status == RideStatus.Formed);
                    var processForm = new RideProcessForm(dbRide);

                    return View(processForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult SuccessForm(int id)
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var successForm = new RideSuccessForm(id);

                    return View(successForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult FailForm(int id)
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var failForm = new RideFailForm(id);

                    return View(failForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult Success(RideSuccessForm successForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("SuccessForm", successForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult Fail(RideFailForm failForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("FailForm", failForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {

                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}