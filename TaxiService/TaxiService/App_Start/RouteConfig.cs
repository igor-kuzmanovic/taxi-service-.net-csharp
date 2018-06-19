using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaxiService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "View",
                url: "{controller}/{action}",
                defaults: new { }
            );

            routes.MapRoute(
                name: "Base",
                url: "{*.}",
                defaults: new { controller = "Base", action = "Index" }
            );
        }
    }
}
