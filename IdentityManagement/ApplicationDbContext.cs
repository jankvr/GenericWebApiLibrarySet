using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cz.Bkk.Generic.IdentityManagement
{
    /// <summary>
    /// Application DB context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Injected constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            // Empty
        }
    }
}
