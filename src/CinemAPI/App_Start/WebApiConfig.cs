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

            // Web API
            ConfigureAttributes(config);

            // Web API routes
            ConfigureRoutes(config);
        }

        private static void ConfigureAttributes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }

        // Web API routes
        private static void ConfigureRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "ProjectionAvailibleSeatsCount",
                routeTemplate: "api/projection/{projectionId}/availibleSeatsCount",
                defaults: new { controller = "projection" }
                );

            config.Routes.MapHttpRoute(
                name: "CreateReservation",
                routeTemplate: "api/reservation/create/{projectionId}/{row}/{col}",
                defaults: new { controller = "reservation", action = "create" }
                );

            config.Routes.MapHttpRoute(
              name: "BuyTicketWithReservation",
              routeTemplate: "api/ticket/bye/{reservationKey}",
              defaults: new { controller = "ticket", action = "buy" }
              );

            config.Routes.MapHttpRoute(
               name: "BuyTicketWithReservation",
               routeTemplate: "api/ticket/bye/{projectionId}/{row}/{col}",
               defaults: new { controller = "ticket", action = "buy" }
               );
        }

        // Register All Areas - done for Help Pages
        private static void ConfigureServices(HttpConfiguration config)
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}