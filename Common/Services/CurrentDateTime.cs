using Cz.Bkk.Generic.Common.IdentityInterfaces;
using System;

namespace Cz.Bkk.Generic.Common.Services
{
    public class CurrentDateTime : ICurrentDateTime
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
}
