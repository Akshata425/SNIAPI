using log4net;
using log4net.Config;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SNIAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Logging
            XmlConfigurator.Configure();

           var logger = LogManager.GetLogger(typeof(WebApiApplication));
            logger.Info("Application started.");
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastException = Server.GetLastError();
            var logger = log4net.LogManager.GetLogger(typeof(WebApiApplication));
            logger.Fatal(lastException);
        }
    }
}
