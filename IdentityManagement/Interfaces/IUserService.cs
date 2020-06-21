using Cz.Bkk.Generic.Common.Models.Input;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface IUserService
    {
        Task<(bool Succeeded, IdentityUser User, IList<string> Roles)> Authenticate(SignInInput input);
    }
}
