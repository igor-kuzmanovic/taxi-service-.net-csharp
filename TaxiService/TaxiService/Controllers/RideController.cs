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
                    var drivers = db.AppUsers.Where(u => u.UserRole == UserRole.Driver).ToList();
                    ViewBag.DriversList = drivers.Select(d => new SelectListItem { Text = $"{d.FirstName} {d.LastName}", Value = d.Id.ToString() });

                    return View();
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
        }
    }
}