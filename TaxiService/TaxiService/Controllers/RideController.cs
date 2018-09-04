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
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Create()
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

        [HttpPost]
        public ActionResult Create(RideCreateForm createForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", createForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var location = new Location(createForm);
                    var driver = db.AppUsers.SingleOrDefault(u => u.Id == createForm.DriverId);
                    var ride = new Ride(location, dbUser, createForm.VehicleType, driver);
                    driver.IsDriverBusy = true;
                    db.Rides.Add(ride);
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }

        [HttpGet]
        public ActionResult Process()
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

        [HttpGet]
        public ActionResult Success(int id)
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

        [HttpPost]
        public ActionResult Success(RideSuccessForm successForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Success", successForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var ride = db.Rides.Include(r => r.Driver).SingleOrDefault(r => r.Id == successForm.RideId);
                    var driver = db.AppUsers.SingleOrDefault(u => u.Id == ride.Driver.Id);
                    var location = new Location(successForm);
                    ride.Update(successForm);
                    driver.IsDriverBusy = false;
                    var updatedUser = new AppUser();
                    updatedUser.GetLoginData(driver);
                    Session["User"] = updatedUser;
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }

        [HttpGet]
        public ActionResult Fail(int id)
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

        [HttpPost]
        public ActionResult Fail(RideFailForm failForm)
        {
            using (var db = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Fail", failForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var ride = db.Rides.Include(r => r.Driver).SingleOrDefault(r => r.Id == failForm.RideId);
                    var driver = db.AppUsers.SingleOrDefault(u => u.Id == ride.Driver.Id);
                    ride.Update(failForm);
                    driver.IsDriverBusy = false;
                    var updatedUser = new AppUser();
                    updatedUser.GetLoginData(driver);
                    Session["User"] = updatedUser;
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}