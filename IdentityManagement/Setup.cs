using Cz.Bkk.Generic.IdentityManagement.IntegrationLayer;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Cz.Bkk.Generic.IdentityManagement.LogicLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cz.Bkk.Generic.IdentityManagement
{
    /// <summary>
    /// Identity management setup used in Startup.cs
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// The whole configuration
        /// </summary>
        /// <param name="services"></param>
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // Add ApplicationContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            // Add identity
            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            // Dependencies registration
            RegisterDependencies(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<RegistrationService>();
            services.AddScoped<IRegistration, Registration>();
        }
    }
}
