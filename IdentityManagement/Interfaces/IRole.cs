using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface IRole
    {
        Task<bool> CreateAsync(string roleName);
    }
}
