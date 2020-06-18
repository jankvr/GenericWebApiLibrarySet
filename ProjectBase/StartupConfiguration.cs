using Cz.Bkk.Generic.IdentityManagement;
using Cz.Bkk.Generic.ProjectBase.AppConfiguration;
using Cz.Bkk.Generic.ProjectBase.MessageHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;

namespace ProjectBase
{
    /// <summary>
    /// 
    /// </summary>
    public static class StartupConfiguration
    {
        /// <summary>
        /// Application configuration
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureApp(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<MessageMiddleware>();
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProfitCosts");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Services configuration
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProfitCosts", Version = "v1" });
            });
            
            // Register in-memory cache
            services.AddMemoryCache();

            // DI registration
            RegisterBaseDependencyInjection(services);

            // Identity management startup configuration
            //Setup.Configure(services, configuration);
        }

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterBaseDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<Settings>();
        }
    }
}
