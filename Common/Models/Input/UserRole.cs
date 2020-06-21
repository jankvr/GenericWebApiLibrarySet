using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cz.Bkk.Generic.Common.Models.Input
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        NORMAL = 0,
        ADMIN = 1
    }
}
