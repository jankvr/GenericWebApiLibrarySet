using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.ServiceLayer
{
    internal class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IdentityRole> Search(string roleName)
        {
            var response = await roleManager.FindByNameAsync(roleName);
            return response;
        }

        public async Task<IdentityResult> Create(string roleName)
        {
            var newRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleName
            };

            var response = await roleManager.CreateAsync(newRole);
            return response;
        }

    }
}
