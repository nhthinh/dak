using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DAK_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = false;
          //  routes.IgnoreRoute("images/{*pathInfo}");
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "DAK", action = "homepage", id = UrlParameter.Optional }
         );
        }
    }
}
