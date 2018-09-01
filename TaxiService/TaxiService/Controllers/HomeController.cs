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

        public ActionResult UserEditForm()
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
                    var userForm = new UserEditForm(dbUser);

                    ViewBag.User = user;
                    return View(userForm);
                }
                else
                {
                    ViewBag.User = user;
                    return RedirectToAction("Home");
                }
            }
        }

        public ActionResult UserEdit(UserEditForm userForm)
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
                    return View("UserEditForm", userForm);
                }

                var dbUser = db.AppUsers.SingleOrDefault(u => u.Id == userForm.Id);
                if (dbUser != null)
                {
                    dbUser.Password = userForm.Password;
                    dbUser.FirstName = userForm.FirstName;
                    dbUser.LastName = userForm.LastName;
                    dbUser.Gender = userForm.Gender;
                    dbUser.UMCN = userForm.UMCN;
                    dbUser.Phone = userForm.Phone;
                    dbUser.Email = userForm.Email;
                    db.SaveChanges();

                    ViewBag.User = user;
                    return RedirectToAction("UserEditForm");
                }
                else
                {
                    ViewBag.User = user;
                    return RedirectToAction("Home");
                }
            }
        }
    }
}