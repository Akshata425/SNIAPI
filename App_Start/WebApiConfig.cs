using Microsoft.Owin.Security.OAuth;
using SNIAPI.Exceptions;
using SNIAPI.Filters;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SNIAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            

            // Web API configuration and services    
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Adding custom exception fileter globally
            config.Filters.Add(new SNIExceptionFilterAttribute());
            config.Filters.Add(new BasicAuthentication());

            // SignalR

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
