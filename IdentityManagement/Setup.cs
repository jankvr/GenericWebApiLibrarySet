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
    public class Setup
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Injected constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Setup(IConfiguration configuration)
        {
            this.configuration = configuration;
        } 

        /// <summary>
        /// The whole configuration
        /// </summary>
        /// <param name="services"></param>
        public void Configure(IServiceCollection services)
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
        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<RegistrationService>();
            services.AddScoped<IRegistration, Registration>();
        }
    }
}
