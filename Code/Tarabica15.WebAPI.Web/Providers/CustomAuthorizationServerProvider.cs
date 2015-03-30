using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Configuration;
using Tarabica15.WebAPI.Contracts.Exceptions;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Web.Common;
using Tarabica15.WebAPI.Web.Helpers;

namespace Tarabica15.WebAPI.Web.Providers
{
    public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAccountManager _accountManager;
        private readonly string _configurationClientId;
        private readonly string _configurationSecret;
        private readonly ILogger _logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAuthorizationServerProvider"/> class.
        /// </summary>
        public CustomAuthorizationServerProvider(ILogger logger, IAccountManager accountManager, IApplicationConfiguration applicationConfiguration)
        {
            _accountManager = accountManager;
            _configurationClientId = applicationConfiguration.AuthenticationClientId;
            _configurationSecret = applicationConfiguration.AuthenticationClientSecret;
            _logger = logger;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string secret = string.Empty;
            string error;

            try
            {
                var result = context.TryGetBasicCredentials(out clientId, out secret);
                if (!result)
                {
                    context.TryGetFormCredentials(out clientId, out secret);
                }
            }
            catch (Exception e)
            {
                error = "Error decoding Authentication header.";
                _logger.Error(error, e);
            }

            if (String.Equals(clientId, _configurationClientId) && String.Equals(secret, _configurationSecret))
            {
                context.Validated();
                return Task.FromResult<object>(null);
            }

            error = "ClientId/Secret are not valid.";
            _logger.Error(error);
            context.SetError(error);
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserDetailsDto userDetails;

            try
            {
                userDetails = _accountManager.LoginUser(context.UserName, context.Password);
            }
            catch (BusinessException ex)
            {
                _logger.Error(ex);
                context.Rejected();
                context.SetError("Authentication Error", ex.Message);
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                context.Rejected();
                context.SetError("Authentication Error", "Internal error.");
                return Task.FromResult(0);
            }

            if (userDetails == null)
            {
                context.Rejected();
                context.SetError("Authentication Error", "Error login user.");
                return Task.FromResult(0);
            }

            var identity = ClaimsUtility.CreateClaimsIdentity(userDetails, context.ClientId, context.Options.AuthenticationType);

            // create metadata to pass on to refresh token provider
            var properties = CreateProperties(userDetails.UserName, context.ClientId);

            var ticket = new AuthenticationTicket(identity, properties);
            context.Validated(ticket);

            context.Request.Context.Authentication.SignIn(identity);
            return Task.FromResult(0);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // not tested -  todo test and define rule to allow refresh
            var originalClient = context.Ticket.Properties.Dictionary["client_id"];
            var currentClient = GetClaimData(context, ClaimTypes.PrimarySid);

            if (string.Equals(originalClient, currentClient))
            {
                var currentSessionId = GetClaimData(context, ClaimTypes.UserData);
                var isVerifySessionOk = _accountManager.VerifyToken(currentSessionId);

                if (isVerifySessionOk)
                {
                    var identity = context.Ticket.Identity;
                    var ticket = new AuthenticationTicket(identity, context.Ticket.Properties);

                    context.Validated(ticket);
                    return Task.FromResult<object>(null);
                }
            }

            context.Rejected();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        
        private static AuthenticationProperties CreateProperties(string userName, string clientId)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add(ApiConstants.AuthenticationKeys.Username, userName);
            data.Add(ApiConstants.AuthenticationKeys.ClientId, clientId);

            return new AuthenticationProperties(data);
        }

        private static string GetClaimData(OAuthGrantRefreshTokenContext context, string claimType)
        {
            string result = null;

            var claimUserData = context.Ticket.Identity.Claims.FirstOrDefault(claim => claim.Type == claimType);
            if (claimUserData != null)
                result = claimUserData.Value;

            return result;
        }
    }
}