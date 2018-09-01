using System;
using System.Collections.Generic;
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
            AppUser user = (AppUser)Session["User"];
            if (user == null)
            {
                user = new AppUser();
                Session["User"] = user;
            }

            ViewBag.User = user;
            return View();
        }

        public ActionResult ProfileEditForm()
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == user.Id);

                if (dbUser != null)
                {
                    var profileEditForm = new ProfileEditForm(dbUser);

                    ViewBag.User = user;
                    return View(profileEditForm);
                }
                else
                {
                    ViewBag.User = user;
                    return RedirectToAction("Home");
                }
            }
        }

        public ActionResult ProfileEdit(ProfileEditForm profileEditForm)
        {
            using (var db = new AppDbContext())
            {
                AppUser user = (AppUser)Session["User"];
                if (user == null)
                {
                    user = new AppUser();
                    Session["User"] = user;
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.User = user;
                    return View("UserEditForm", profileEditForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == profileEditForm.Id);
                if (dbUser != null)
                {
                    dbUser.Password = profileEditForm.Password;
                    dbUser.FirstName = profileEditForm.FirstName;
                    dbUser.LastName = profileEditForm.LastName;
                    dbUser.Gender = profileEditForm.Gender;
                    dbUser.UMCN = profileEditForm.UMCN;
                    dbUser.Phone = profileEditForm.Phone;
                    dbUser.Email = profileEditForm.Email;
                    db.SaveChanges();
                }

                ViewBag.User = user;
                return RedirectToAction("Home");
            }
        }
    }
}