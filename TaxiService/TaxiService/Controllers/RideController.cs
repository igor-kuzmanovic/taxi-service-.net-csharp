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
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Dispatcher)
            {
                return new HttpUnauthorizedResult();
            }

            var drivers = db.AppUsers.Where(u => u.Role == UserRole.Driver && !u.IsDriverBusy.Value).ToList();
            var driverList = drivers.Select(d => new SelectListItem { Text = $"{d.FirstName} {d.LastName}", Value = d.Id.ToString() });
            ViewBag.DriversList = new SelectList(driverList, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RideCreateForm form)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Dispatcher)
            {
                return new HttpUnauthorizedResult();
            }

            if (!ModelState.IsValid)
            {
                return View("Create", form);
            }

            var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }

            var location = new Location(form);
            var driver = db.AppUsers.SingleOrDefault(u => u.Id == form.DriverId);
            var ride = new Ride(location, dbUser, form.VehicleType, driver);
            driver.IsDriverBusy = true;
            db.Rides.Add(ride);
            db.SaveChanges();

            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public ActionResult Process()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            var dbRide = db.Rides.Include(r => r.Source).Include(r => r.Dispatcher).FirstOrDefault(r => r.Driver.Id == user.Id && r.Status == RideStatus.Formed);
            var processForm = new RideProcessForm(dbRide);

            return View(processForm);
        }

        [HttpGet]
        public ActionResult Success(int id)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            var successForm = new RideSuccessForm(id);

            return View(successForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Success(RideSuccessForm form)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            if (!ModelState.IsValid)
            {
                return View("Success", form);
            }

            var ride = db.Rides.Include(r => r.Driver).SingleOrDefault(r => r.Id == form.RideId);
            var driver = db.AppUsers.SingleOrDefault(u => u.Id == ride.Driver.Id);
            var location = new Location(form);
            ride.Update(form);
            driver.IsDriverBusy = false;
            var updatedUser = new AppUser();
            updatedUser.GetLoginData(driver);
            Session["User"] = updatedUser;
            db.SaveChanges();

            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public ActionResult Fail(int id)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            var failForm = new RideFailForm(id);

            return View(failForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fail(RideFailForm form)
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            if (!ModelState.IsValid)
            {
                return View("Fail", form);
            }

            var ride = db.Rides.Include(r => r.Driver).SingleOrDefault(r => r.Id == form.RideId);
            var driver = db.AppUsers.SingleOrDefault(u => u.Id == ride.Driver.Id);
            ride.Update(form);
            driver.IsDriverBusy = false;
            var updatedUser = new AppUser();
            updatedUser.GetLoginData(driver);
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