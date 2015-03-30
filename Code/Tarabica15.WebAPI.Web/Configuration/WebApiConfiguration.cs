using System.Web.Http;
using Owin;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public static class WebApiConfiguration
    {
        public static void Configure(HttpConfiguration config, IAppBuilder app)
        {
            DependencyConfiguration.Configure(config);
            AuthConfiguration.Configure(app);
            RoutesConfiguration.Configure(config);
            FormattersConfiguration.Configure(config);
            FiltersConfiguration.Configure(config);
        }
    }
}
