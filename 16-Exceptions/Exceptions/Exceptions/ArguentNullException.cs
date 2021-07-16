using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    internal class ArguentNullException : Exception
    {
        public ArguentNullException()
        {
        }

        public ArguentNullException(string message) : base(message)
        {
        }

        public ArguentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArguentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}