using System;
using System.Collections.Generic;
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
            return RedirectToAction("EditForm");
        }

        public ActionResult EditForm()
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }
                ViewBag.User = user;

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);

                if (dbUser != null)
                {
                    var editForm = new ProfileEditForm(dbUser);

                    return View(editForm);
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
        }

        public ActionResult Edit(ProfileEditForm editForm)
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }
                ViewBag.User = user;

                if (!ModelState.IsValid)
                {                   
                    return View("EditForm", editForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == editForm.Id);
                if (dbUser != null)
                {
                    dbUser.Update(editForm);
                    db.SaveChanges();
                }

                return RedirectToAction("Home", "Home");
            }
        }
    }
}