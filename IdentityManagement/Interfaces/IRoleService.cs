using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityRole> Search(string roleName);

        Task<IdentityResult> Create(string roleName);
    }
}
