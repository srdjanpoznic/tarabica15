using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Tarabica15.WebAPI.Contracts.Configuration;

namespace Tarabica15.WebAPI.Web.Providers
{
    public class CustomRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static readonly ConcurrentDictionary<string, AuthenticationTicket> RefreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();
        private readonly TimeSpan _tokenExpiration;

        public CustomRefreshTokenProvider(IApplicationConfiguration applicationConfiguration)
        {
            _tokenExpiration = TimeSpan.FromHours(applicationConfiguration.TokenExpireTimeoutInMinutes);
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return null;
            }

            var refreshTokenId = Guid.NewGuid().ToString();

            // maybe only create a handle the first time, then re-use for same client
            // copy properties and set the desired lifetime of refresh token
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.Add(_tokenExpiration)
            };

            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            var existing = RefreshTokens.FirstOrDefault(i => i.Key == refreshTokenId);

            AuthenticationTicket ticket;

            if (RefreshTokens.TryRemove(context.Token, out ticket))
            {
                RefreshTokens.TryAdd(refreshTokenId, refreshTokenTicket);
            }

            // consider storing only the hash of the handle
            context.SetToken(refreshTokenId);

            return Task.FromResult<object>(null);
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = Helper.GetHash(context.Token);

            AuthenticationTicket ticket;

            if (RefreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }

            return Task.FromResult<object>(null);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}