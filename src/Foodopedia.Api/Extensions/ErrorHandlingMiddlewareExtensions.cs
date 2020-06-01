using Foodopedia.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Foodopedia.Api.Extensions
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}