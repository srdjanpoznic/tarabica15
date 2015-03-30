using System.Web.Http;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Web.Filters;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public static class FiltersConfiguration
    {
        public static void Configure(HttpConfiguration config)
        {
            var logger = DependencyConfiguration.GetContainer().Resolve<ILogger>();
            config.Filters.Add(new ApiExceptionFilterAttribute(logger));
            config.Filters.Add(new CustomAuthorizeAttribute(logger));
        }
    }
}
