using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.Common.Models.Input
{   
    /// <summary>
    /// Sign in input model
    /// </summary>
    public class SignInInput
    {
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
