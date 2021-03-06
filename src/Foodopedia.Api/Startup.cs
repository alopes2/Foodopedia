using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using AutoMapper;
using FluentValidation.AspNetCore;
using Foodopedia.Api.Extensions;
using Foodopedia.Api.Metrics;
using Foodopedia.Api.Settings;
using Foodopedia.Core.Clients;
using Foodopedia.OpenFoodFacts;
using Foodopedia.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Prometheus;

namespace Foodopedia.Api
{
    public class Startup
    {
        private AppSettings _appSettings;
        private OpenFoodFactsSettings _openFoodFactsSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _appSettings = Configuration.GetSection("App").Get<AppSettings>();
            _openFoodFactsSettings = Configuration.GetSection("OpenFoodFacts").Get<OpenFoodFactsSettings>();

            services.AddControllers()
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssembly(typeof(Startup).Assembly);
                });

            services.AddSwagger(_appSettings);

            services.AddHttpClient<IOpenFoodFactsClient, OpenFoodFactsClient>(options =>
            {
                options.BaseAddress = new Uri(_openFoodFactsSettings.BaseAddress);
            });
            
            services.AddSingleton<IMetricsService, MetricsService>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServices();

            services.AddRateLimit(Configuration);

            services.AddAutoMapper(typeof(Startup), typeof(OpenFoodFactsClient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGlobalErrorHandling();

            app.UseHttpsRedirection();

            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseMetrics();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });

            app.UseSwaggerConfiguration(_appSettings);
        }
    }
}
