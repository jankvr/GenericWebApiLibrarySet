using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.Interfaces.Identity
{
    /// <summary>
    /// Registration interface
    /// </summary>
    public interface IRegistration
    {
        Task<bool> CreateAsync(RegistrationInput input);
    }
}
