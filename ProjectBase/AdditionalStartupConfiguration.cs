using Cz.Bkk.Generic.IdentityManagement;
using Cz.Bkk.Generic.ProjectBase.AppConfiguration;
using Cz.Bkk.Generic.ProjectBase.MessageHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;

namespace ProjectBase
{
    /// <summary>
    /// 
    /// </summary>
    public class AdditionalStartupConfiguration
    {
        private readonly Setup identitySetup;

        /// <summary>
        /// Injected constructor
        /// </summary>
        /// <param name="configuration"></param>
        public AdditionalStartupConfiguration(Setup identitySetup)
        {
            this.identitySetup = identitySetup;
        }

        /// <summary>
        /// Services configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Identity management startup configuration
            identitySetup.Configure(services);
            // Register in-memory cache
            services.AddMemoryCache();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProfitCosts", Version = "v1" });
            });
        }

        /// <summary>
        /// Application configuration
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureApp(IApplicationBuilder app)
        {
            app.UseMiddleware<MessageMiddleware>();
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProfitCosts");
            });
        }

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterBaseDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<Cz.Bkk.Generic.IdentityManagement.Setup>();
            services.AddSingleton<AdditionalStartupConfiguration>();
            services.AddSingleton<Settings>();
        }
    }
}
