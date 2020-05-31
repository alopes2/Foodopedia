using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodopedia.Api.Extensions
{
    public static class RateLimitExtensions
    {
        public static IServiceCollection AddRateLimit(this IServiceCollection services, IConfiguration configuration)
        {
            	// needed to store rate limit counters and ip rules
	        services.AddMemoryCache();

	        //load general configuration from appsettings.json
	        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

	        //load ip rules from appsettings.json
	        services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

	        // inject counter and rules stores
	        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
	        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            return services;
        }
    }
}