using Cz.Bkk.Generic.Common.Model.Response;
using Cz.Bkk.Generic.IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.IntegrationLayer
{
    /// <summary>
    /// User registration class. Calls .NET Core Identity manager for signing in
    /// </summary>
    public class RegistrationService
    {
        private UserManager<ApplicationUser> userManager;

        public RegistrationService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(RegistrationInput input)
        {
            var newUser = new ApplicationUser { Id = Guid.NewGuid().ToString(), Email = input.Email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(newUser, input.Password);
            return result;
        }
    }
}
