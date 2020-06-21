using Cz.Bkk.Generic.Common.Models.Input;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface IRegistrationService
    {
        Task<IdentityResult> CreateAsync(UserInput input);
    }
}
