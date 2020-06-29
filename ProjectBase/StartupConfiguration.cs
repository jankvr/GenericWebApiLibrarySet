using Cz.Bkk.Generic.Common.IdentityInterfaces;
using Cz.Bkk.Generic.Common.Services;
using Cz.Bkk.Generic.ProjectBase.AppConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cz.Bkk.Generic.ProjectBase
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
        public static void ConfigureApp(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["App:Name"]);

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = configuration["App:Name"], Version = configuration["App:Version"] });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });
            
            // Register in-memory cache
            services.AddMemoryCache();

            // Dependency Injection registration
            RegisterBaseDependencyInjection(services);

            Cz.Bkk.Generic.CacheLibrary.Setup.RegisterDependencies(services);
            Cz.Bkk.Generic.IdentityManagement.Setup.RegisterDependencies(services);

            // Identity management startup configuration
            Cz.Bkk.Generic.IdentityManagement.Setup.Configure(services, configuration);
        }

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterBaseDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<Settings>();
            services.AddSingleton<ICurrentDateTime, CurrentDateTime>();
        }
    }
}
