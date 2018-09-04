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
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.Include(u => u.Vehicle).SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var dbVehicle = db.Vehicles.SingleOrDefault(v => v.Id == dbUser.Vehicle.Id);
                    var editForm = new VehicleEditForm(dbVehicle);

                    return View(editForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(VehicleEditForm editForm)
        {
            using (var db = new AppDbContext())
            {              
                if (!ModelState.IsValid)
                {
                    return View("Edit", editForm);
                }

                if (db.Vehicles.Any(v => v.Identification == editForm.Identification))
                {
                    return View("Edit", editForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var dbVehicle = db.Vehicles.SingleOrDefault(v => v.Id == editForm.Id);
                    dbVehicle.Update(editForm);
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}