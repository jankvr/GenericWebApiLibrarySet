using System;
using System.Runtime.Serialization;

namespace Cz.Bkk.Generic.Common.Models.Exceptions
{
    [Serializable]
    public class NoCacheKeyFoundException : Exception
    {
        public NoCacheKeyFoundException()
        {
        }

        public NoCacheKeyFoundException(string message) : base(message)
        {
        }

        public NoCacheKeyFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoCacheKeyFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}