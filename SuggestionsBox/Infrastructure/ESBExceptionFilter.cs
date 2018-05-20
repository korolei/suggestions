using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http.Filters;

namespace SuggestionsBox.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EsbExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ValidationException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, actionExecutedContext.Exception.Message.Replace("\r\n", ";"));
            }
            else if (actionExecutedContext.Exception is SecurityException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authotization Error. Please contact Technical Support.");
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message);
            }
            LogWrapper.Log(actionExecutedContext.Exception);
        }
    }
}