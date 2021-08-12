using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace QuoteAPI.CustomExceptionFilter
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMassage = "";
            var exceptionType = actionExecutedContext.Exception.GetType();
            if (exceptionType == typeof(NullReferenceException))
            {
                errorMassage = "Data cannot be null.";
                statusCode = HttpStatusCode.Forbidden;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                errorMassage = "Data not found.";
                statusCode = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(DbUpdateConcurrencyException) || exceptionType == typeof(DbUpdateException))
            {
                errorMassage = "Failed to update.";
                statusCode = HttpStatusCode.Conflict;
            }
            else
            {
                errorMassage = "Contact to Admin.";
                statusCode = HttpStatusCode.InternalServerError;
            }
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorMassage),
                ReasonPhrase = "From Exception Filter"
            };
            actionExecutedContext.Response = response;
        }
    }
}