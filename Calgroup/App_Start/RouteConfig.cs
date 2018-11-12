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
               name: "Search",
               url: "Search/{searchString}",
               defaults: new { controller = "Home", action = "Search", searchString = UrlParameter.Optional }
               );

            routes.MapRoute(
               name: "getSearch",
               url: "searchSanPham/{searchString}",
               defaults: new { controller = "Home", action = "searchSanPham", searchString = UrlParameter.Optional }
               );

            routes.MapRoute(
               name: "Library",
               url: "ThuVien/{aliascat}",
               defaults: new { controller = "Home", action = "Library", aliascat = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Libraries",
                url: "getThuVien/{aliascat}",
                defaults: new { controller = "Home", action = "getThuVien", aliascat = UrlParameter.Optional }
                );

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
               defaults: new { controller = "home", action = "NewsDetail", id = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
