using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Tarabica15.WebAPI.Common.Logging;

namespace Tarabica15.WebAPI.Web.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ILogger _logger;

        public CustomAuthorizeAttribute(ILogger logger)
        {
            _logger = logger;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (ClaimsPrincipal.Current.Identity.IsAuthenticated)
            {
                // User not in role
                _logger.ErrorFormat("Unauthorized user access of controller: [{0}], action: [{1}]", GetControllerName(actionContext), GetActionName(actionContext));
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Not authorized.");
            }
            else
            {
                // User not authenticated
                _logger.ErrorFormat("Unauthenticated user access of controller: [{0}], action: [{1}]", GetControllerName(actionContext), GetActionName(actionContext));
                base.HandleUnauthorizedRequest(actionContext);
            }
        }

        private static string GetActionName(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.ActionName;
        }

        private static string GetControllerName(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        }
    }
}