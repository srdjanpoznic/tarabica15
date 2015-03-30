using System;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Configuration;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Web.Providers;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public static class AuthConfiguration
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
       
        public static void Configure(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.SetDefaultSignInAsAuthenticationType("External");

            var logger = DependencyConfiguration.GetContainer().Resolve<ILogger>();
            var configuration = DependencyConfiguration.GetContainer().Resolve<IApplicationConfiguration>();

            var accountManager = DependencyConfiguration.GetContainer().Resolve<IAccountManager>();

            app.UseCors(CorsOptions.AllowAll);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(configuration.TokenExpireTimeoutInMinutes),
                Provider = new CustomAuthorizationServerProvider(logger, accountManager, configuration)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}
