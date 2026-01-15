using ClaimsProcessor.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClaimsProcessor.API.Handler
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ApiError apiError;
            if (context.Exception is ClaimApplicationException appEx)
            {
                apiError = new ApiError
                {
                    Message = appEx.Message,
                };
                context.HttpContext.Response.StatusCode = 400;
            }
            else if (context.Exception is ClaimAPIException apiEx)
            {
                apiError = new ApiError
                {
                    Message = apiEx.Message,
                };
                context.HttpContext.Response.StatusCode = 422;
            }
            else
            {
                apiError = new ApiError
                {
                    Message = "An unexpected error occurred.",
                };
                context.HttpContext.Response.StatusCode = 500;
            }
            context.Result = new JsonResult(apiError);
            context.ExceptionHandled = true;
        }
    }
}
