using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calgroup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Products",
                url: "getSanPham/{aliascat}",
                defaults: new { controller = "Home", action = "getSanPham", aliascat = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Detail",
                url: "ChiTiet/{alias}",
                defaults: new { controller = "Home", action = "ChiTiet", alias = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Category",
                url: "SanPham/{aliascat}",
                defaults: new { controller = "Home", action = "SanPham", aliascat = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "News",
               url: "News/{metatitle}-{id}",
               defaults: new { controller = "News", action = "NewsDetail", id = UrlParameter.Optional }
               //namespaces: new[] { "Fix24h_AdobeBricks_V1.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FAQ",
                url: "{controller}/{alias}",
                defaults: new { controller = "FAQ", action = "Index", aias = UrlParameter.Optional }
            );
        }
    }
}
