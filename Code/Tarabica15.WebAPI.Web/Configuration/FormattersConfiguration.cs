using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public static class FormattersConfiguration
    {
        public static void Configure(HttpConfiguration config)
        {
            //#jsonser
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        }
    }
}
