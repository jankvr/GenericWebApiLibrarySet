using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.Common.Models.Response
{
    /// <summary>
    /// JWT Token
    /// </summary>
    public class SignIn
    {
        /// <summary>
        /// Stringified token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Success indication
        /// </summary>
        public bool Succeeded { get; set; }
    }
}
