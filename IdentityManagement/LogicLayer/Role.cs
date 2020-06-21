using Cz.Bkk.Generic.Common.Models.Exceptions;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.LogicLayer
{
    internal class Role : IRole
    {
        private readonly IRoleService service;

        public Role(IRoleService service)
        {
            this.service = service;
        }

        public async Task<bool> CreateAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException($"{nameof(roleName)} is null or empty.");
            }

            var role = await service.Search(roleName);

            if (role != null)
            {
                return false;
            }

            var response = await service.Create(roleName);

            if (response?.Errors?.Count() > 0)
            {
                var errors = string.Join(" ", response?.Errors?.Select(e => e.Description));
                throw new NotCreatedException(errors);
            }

            return true;
        }
    }
}
