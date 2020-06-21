using Cz.Bkk.Generic.Common.Models.Input;
using Cz.Bkk.Generic.Common.Models.Response;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    /// <summary>
    /// Registration interface
    /// </summary>
    public interface IUser
    {
        Task<SignIn> Authenticate(SignInInput input);
    }
}

