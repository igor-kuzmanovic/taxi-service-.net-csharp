using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiService.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Registration()
        {
            return new FilePathResult("~/AngularJS/Views/Registration.html", "text/html");
        }

        public ActionResult Login()
        {
            return new FilePathResult("~/AngularJS/Views/Login.html", "text/html");
        }

        public ActionResult Home()
        {
            return new FilePathResult("~/AngularJS/Views/Home.html", "text/html");
        }
    }
}