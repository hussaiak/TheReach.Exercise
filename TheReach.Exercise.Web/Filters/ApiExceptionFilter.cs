using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 
using System;
using System.Net;
using TheReach.Exercise.Web.Common;

namespace TheReach.Exercise.Web.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var errorResponse = new ErrorResponse
            {
                Code = context.Exception.HResult.ToString(),
                Message = GetErrorMessage(context.Exception)
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            base.OnException(context);
        }

        private string GetErrorMessage(Exception exception, bool getFullDetails = true)
        {
            var baseException = exception.GetBaseException();

            var errorMessgae = baseException == exception
                ? $"{baseException.GetType()}:{baseException.Message}{baseException.StackTrace}"
                : $"{exception.GetType()}:{exception.Message} --->" +
                 $"{baseException.GetType()}:{baseException.Message} {baseException.StackTrace}{exception.StackTrace}";

            if (!getFullDetails)
            {
                errorMessgae = $"{baseException.GetType()}:{baseException.Message}";
            }

            return errorMessgae.Trim();
        }
    }
}