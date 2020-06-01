using System;
using System.Net;
using System.Threading.Tasks;
using Foodopedia.Api.Models;
using Foodopedia.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Foodopedia.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var details = new ErrorDetails
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = $"Exception message: {exception.Message}.",
                Title = "An unexpected error occurred."
            };

            if (exception.InnerException != null)
            {
                details.Message += $" Inner message: {exception.InnerException.Message}";
            }

            if (exception is HttpErrorException httpErrorException)
            {
                details.StatusCode = httpErrorException.StatusCode;
                details.Message = httpErrorException.Message;
                details.Title = httpErrorException.Title;
            }

            await WriteResponse(context, details);
        }

        private static async Task WriteResponse(HttpContext context, ErrorDetails details)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)details.StatusCode;
            await context.Response.WriteAsync(details.ToString());
        }
    }
}