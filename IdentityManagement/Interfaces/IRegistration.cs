﻿using Cz.Bkk.Generic.Common.Models.Input;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    /// <summary>
    /// Registration interface
    /// </summary>
    public interface IRegistration
    {
        Task<string> CreateAsync(UserInput input);
    }
}
