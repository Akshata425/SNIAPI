using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SNIAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ASP.NET Web API Route Config
            routes.MapHttpRoute(
            name: "swagger_root",
            routeTemplate: "",
            defaults: null,
            constraints: null,
            handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Payment",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Payment", action = "Index", id = UrlParameter.Optional }
            );
        
        }
    }
}
