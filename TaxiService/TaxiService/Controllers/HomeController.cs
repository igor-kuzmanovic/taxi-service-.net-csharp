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
            var user = (AppUser)Session["User"];

            if (user.Role == UserRole.Dispatcher)
            {
                return RedirectToAction("HomeDispatcher");
            }
            else
            {
                return RedirectToAction("HomeDriver");
            }
        }

        public ActionResult HomeDispatcher()
        {
            return View();
        }

        public ActionResult HomeDriver()
        {
            return View();
        }
    }
}