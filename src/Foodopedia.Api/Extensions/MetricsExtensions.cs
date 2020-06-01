using Foodopedia.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace Foodopedia.Api.Extensions
{
    public static class MetricsExtensions
    {
        
        /// <summary>
        /// Initialize Metrics middleware and Prometheus HttpMetrics middleware.
        /// </summary>
        public static IApplicationBuilder UseMetrics(this IApplicationBuilder app)
        {
            app.UseHttpMetrics();
            app.UseMiddleware<MetricsMiddleware>();

            return app;
        }
    }
}