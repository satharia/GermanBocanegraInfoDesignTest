using Amazon.SecretsManager.Model;
using GermanBocanegra.Test.Infodesign.Domain.Models.Presenters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GermanBocanegra.Test.Infodesign.API.Filters
{
    public class FallbackExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var response = new BaseResponse()
            {
                Message = context.Exception.Message,
            };

            if (exceptionType.Equals(typeof(ResourceNotFoundException)))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else if (exceptionType.Equals(typeof(ResourceNotFoundException)))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            context.Result = new ObjectResult(response);
        }
    }
}
