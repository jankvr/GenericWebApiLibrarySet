using System;
using System.Runtime.Serialization;

namespace Cz.Bkk.Generic.Common.Models.Exceptions
{
    [Serializable]
    public class NotCreatedException : Exception
    {
        public NotCreatedException()
        {
        }

        public NotCreatedException(string message) : base(message)
        {
        }

        public NotCreatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotCreatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}