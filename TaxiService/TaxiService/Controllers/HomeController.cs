using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;

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
    }
}