using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface IToken
    {
        string Generate(IdentityUser user, IList<string> roles);
    }
}
