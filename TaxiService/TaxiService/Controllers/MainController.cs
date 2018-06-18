using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiService.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return new FilePathResult("~/Views/Partials/Test.html", "text/html");
        }

        public ActionResult Registration()
        {
            return new FilePathResult("~/Views/Partials/Registration.html", "text/html");
        }

        public ActionResult Login()
        {
            return new FilePathResult("~/Views/Partials/Login.html", "text/html");
        }

        public ActionResult Home()
        {
            return new FilePathResult("~/Views/Partials/Home.html", "text/html");
        }
    }
}
