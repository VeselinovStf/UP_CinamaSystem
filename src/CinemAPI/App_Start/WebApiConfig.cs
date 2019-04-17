using System;
using System.Web.Http;
using System.Web.Mvc;

namespace CinemAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ConfigureServices(config);

            // Web API routes
            ConfigureRoutes(config);
            
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Index" }
                );
        }

        private static void ConfigureServices(HttpConfiguration config)
        {
            // Register All Areas - done for Help Pages
            AreaRegistration.RegisterAllAreas();
        }
    }
}