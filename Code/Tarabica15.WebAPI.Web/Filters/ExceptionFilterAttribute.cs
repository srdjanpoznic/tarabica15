using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Exceptions;

namespace Tarabica15.WebAPI.Web.Filters
{
    //200 - OK
    //201 - Created
    //400 - Bad Request
    //304 - Not Modified
    //401 - Unauthorized
    //404 - Not Found
    //403 - Forbidden
    //500 - Internal Server Error
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiExceptionFilterAttribute(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response;
            var controller = GetControllerName(actionExecutedContext);
            var action = GetActionName(actionExecutedContext);

            var exceptionType = actionExecutedContext.Exception.GetType();
            
            if (exceptionType == typeof(BusinessException))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(actionExecutedContext.Exception.Message),
                    ReasonPhrase = "Business logic exception",
                };
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(actionExecutedContext.Exception.Message),
                    ReasonPhrase = "Argument exception",
                };
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content =
                        new StringContent(
                            String.Format("Controller {0} on action {1} has thrown exception: {2}",
                            controller,
                            action,
                            actionExecutedContext.Exception.Message)),
                    ReasonPhrase = "Unhandled Exception",
                };
            }

            actionExecutedContext.Response = response;
            
            LogException(actionExecutedContext, controller, action);

            base.OnException(actionExecutedContext);
        }

        private void LogException(HttpActionExecutedContext actionExecutedContext, string controller, string action)
        {
            _logger.Error(
                string.Format("Exception thrown on controller: [{0}], Action: [{1}] \r\n Request: {2} .",
                    controller, action, actionExecutedContext.Request), actionExecutedContext.Exception);
        }

        private static string GetActionName(HttpActionExecutedContext actionExecutedContext)
        {
            return actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
        }

        private static string GetControllerName(HttpActionExecutedContext actionExecutedContext)
        {
            return actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        }
    }
}