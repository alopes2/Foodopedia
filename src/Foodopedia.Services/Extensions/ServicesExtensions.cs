using Foodopedia.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Foodopedia.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOpenFoodFactsService, OpenFoodFactsService>();

            return services;
        }
    }
}