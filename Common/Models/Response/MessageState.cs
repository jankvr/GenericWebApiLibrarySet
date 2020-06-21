using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.Common.Models.Response
{
    /// <summary>
    /// Possible response states
    /// </summary>
    public enum MessageState
    {
        /// <summary>
        /// Everything is okay
        /// </summary>
        OK = 0,
        /// <summary>
        /// Some kind of problem might appear
        /// </summary>
        WARNING = 1,
        /// <summary>
        /// Fatal error
        /// </summary>
        ERROR = 2
    }
}
