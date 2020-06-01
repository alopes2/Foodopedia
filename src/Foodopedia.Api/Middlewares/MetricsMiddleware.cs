using System;
using System.Threading.Tasks;
using Foodopedia.Api.Metrics;
using Foodopedia.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Foodopedia.Api.Middlewares
{
    public class MetricsMiddleware
    {
        private readonly IMetricsService _metricsService;

        private readonly RequestDelegate _next;

        public MetricsMiddleware(RequestDelegate next, IMetricsService metricsService)
        {
            _next = next;
            _metricsService = metricsService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                // Should only log unhandled and impredicted exceptions
                if (!(e is HttpErrorException))
                {
                    _metricsService.UnhandledExceptionsCounter.Inc();
                }
                
                throw e;
            }
        }
    }
}