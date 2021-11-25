using System.Web.Mvc;
using System.Web.Routing;

namespace TurkEParaDisEntegrasyonSistemi
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "AccountMovement", id = UrlParameter.Optional }
            );
        }
    }
}
