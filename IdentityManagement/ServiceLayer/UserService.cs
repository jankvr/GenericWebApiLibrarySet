using Cz.Bkk.Generic.Common.Models.Input;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.ServiceLayer
{
    internal class UserService : IUserService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public UserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<(bool Succeeded, IdentityUser User, IList<string> Roles)> Authenticate(SignInInput input)
        {
            // Find user
            var foundUser = await userManager.FindByNameAsync(input.UserName);
            var result = await signInManager.CheckPasswordSignInAsync(foundUser, input.Password, false);

            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(foundUser);
                return (true, foundUser, roles);
            }

            return (false, null, null);
        }
    }
}
