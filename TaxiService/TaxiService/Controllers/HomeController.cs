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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Home");
        }

        public ActionResult Home()
        {
            var user = (AppUser)Session["User"];

            if (user.Role == UserRole.Dispatcher)
            {
                return RedirectToAction("HomeDispatcher");
            }

            return RedirectToAction("HomeDriver");
        }

        public ActionResult HomeDispatcher()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var rides = db.Rides.Include(r => r.Dispatcher)
                        .Include(r => r.Driver)
                        .Include(r => r.Source)
                        .Include(r => r.Destination)
                        .Include(r => r.Comment)
                        .ToList()
                        .Select(r => new RideTableRow(r));

                    return View(rides);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult HomeDriver()
        {
            using (var db = new AppDbContext())
            {
                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var rides = db.Rides.Include(r => r.Dispatcher)
                        .Include(r => r.Driver)
                        .Include(r => r.Source)
                        .Include(r => r.Destination)
                        .Include(r => r.Comment)
                        .Where(r => r.Driver.Id == dbUser.Id)
                        .ToList()
                        .Select(r => new RideTableRow(r));

                    return View(rides);
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}