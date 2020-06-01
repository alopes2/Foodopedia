using Foodopedia.Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Foodopedia.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, AppSettings settings)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(settings.Version, new OpenApiInfo { Title = settings.Name, Version = settings.Version });
            });

            return services;
        }
        
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, AppSettings settings)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{settings.Name} {settings.Version}");
            });

            return app;
        }
    }
}