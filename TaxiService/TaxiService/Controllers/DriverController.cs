using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;
using TaxiService.ViewModels;

namespace TaxiService.Controllers
{
    public class DriverController : Controller
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
                    return View();
                }

                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult Create(DriverCreateForm createForm)
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
                    var driver = new AppUser(createForm);
                    db.AppUsers.Add(driver);
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}