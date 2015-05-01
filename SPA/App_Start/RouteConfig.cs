using System.Web.Mvc;
using System.Web.Routing;

namespace SPA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            
            routes.MapRoute(
                "CatchAll",
                "{*catchall}",
                new
                {
                    Controller = "Home",
                    Action = "Index"
                });


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
