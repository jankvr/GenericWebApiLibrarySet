using Cz.Bkk.Generic.IdentityManagement.Models;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    /// <summary>
    /// Registration interface
    /// </summary>
    public interface IRegistration
    {
        Task<bool> CreateAsync(RegistrationInput input);
    }
}
