using Cz.Bkk.Generic.CacheLibrary.Interfaces;
using Cz.Bkk.Generic.Common.Models.Exceptions;
using Cz.Bkk.Generic.Common.Models.Input;
using Cz.Bkk.Generic.Common.Models.Response;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using System;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.LogicLayer
{
    internal class User : IUser
    {
        private readonly IUserService service;
        private readonly IToken jwtToken;
        private readonly ICache cache;

        public User(IUserService service, IToken jwtToken, ICache cache)
        {
            this.service = service;
            this.jwtToken = jwtToken;
            this.cache = cache;
        }

        public async Task<SignIn> Authenticate(SignInInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{nameof(input)} is null.");
            }
            var response = await service.Authenticate(input);

            if (!response.Succeeded)
            {
                throw new NotAuthenticatedException();
            }

            var result = new SignIn
            {
                Token = jwtToken.Generate(response.User, response.Roles),
                Succeeded = response.Succeeded
            };

            // Save to cache
            await cache.Set(response.User?.Id, result);

            return result;
        }
    }
}
