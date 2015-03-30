using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Tarabica15.WebAPI.Web;
using Tarabica15.WebAPI.Web.Configuration;

[assembly: OwinStartup(typeof(Startup))]
namespace Tarabica15.WebAPI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfiguration.Configure(config, app);
            app.UseWebApi(config);
        }
    }
}