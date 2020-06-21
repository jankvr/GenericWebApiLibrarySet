using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Cz.Bkk.Generic.IdentityManagement.LogicLayer;
using Cz.Bkk.Generic.IdentityManagement.Models;
using Cz.Bkk.Generic.IdentityManagement.ServiceLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            var builder = services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddRoleValidator<RoleValidator<IdentityRole>>();
            builder.AddRoleManager<RoleManager<IdentityRole>>();
            builder.AddUserManager<UserManager<IdentityUser>>();
            builder.AddSignInManager<SignInManager<IdentityUser>>();
            builder.AddDefaultTokenProviders();
            //builder.add

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Security:Key"])),
                    ValidIssuer = configuration["Security:Issuer"],
                    ValidAudience = configuration["Security:Audience"]
                };
            });
        }

        /// <summary>
        /// Dependencies
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterDependencies(IServiceCollection services)
        {
            // Service layer
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            // Logic layer
            services.AddScoped<IRegistration, Registration>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IRole, Role>();
            services.AddScoped<IToken, Token>();
            // Currently logged user
            services.AddScoped<ICurrentlyLoggedUser, CurrentlyLoggedUser>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
