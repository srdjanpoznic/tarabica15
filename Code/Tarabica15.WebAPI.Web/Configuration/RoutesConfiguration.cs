using System.Web.Http;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public static class RoutesConfiguration
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            
            //config.Routes.MapHttpRoute(
            //    name: "WebApiWithActionRouteName",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}
