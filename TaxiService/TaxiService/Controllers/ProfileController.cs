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
    public class ProfileController : Controller
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
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    var editForm = new ProfileEditForm(dbUser);

                    return View(editForm);
                }

                return RedirectToAction("Home", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(ProfileEditForm editForm)
        {
            using (var db = new AppDbContext())
            {               
                if (!ModelState.IsValid)
                {                   
                    return View("Edit", editForm);
                }

                var user = (AppUser)Session["User"];
                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);
                if (dbUser != null)
                {
                    dbUser.Update(editForm);
                    var updatedUser = new AppUser();
                    updatedUser.GetLoginData(dbUser);
                    Session["User"] = updatedUser;
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}