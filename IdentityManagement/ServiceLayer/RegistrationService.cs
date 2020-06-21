using Cz.Bkk.Generic.Common.Models.Input;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.ServiceLayer
{
    /// <summary>
    /// User registration class. Calls .NET Core Identity manager for signing in
    /// </summary>
    internal class RegistrationService : IRegistrationService
    {
        private UserManager<IdentityUser> userManager;

        public RegistrationService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(UserInput input)
        {
            var newUser = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = input.UserName, Email = input.Email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(newUser, input.Password);
            var roleAssignment = await userManager.AddToRoleAsync(newUser, input.Role.ToString());
            return result;
        }
    }
}
