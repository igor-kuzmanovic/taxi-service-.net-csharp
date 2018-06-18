using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiService.Controllers
{
    public class RouteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return new FilePathResult("~/Views/Test.html", "text/html");
        }
    }
}
