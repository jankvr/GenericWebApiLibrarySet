using System;
using System.Runtime.Serialization;

namespace Cz.Bkk.Generic.Common.Models.Exceptions
{
    [Serializable]
    public class CacheAlreadySetException : Exception
    {
        public CacheAlreadySetException()
        {
        }

        public CacheAlreadySetException(string message) : base(message)
        {
        }

        public CacheAlreadySetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CacheAlreadySetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}