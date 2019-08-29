using System;
using System.Runtime.Serialization;

namespace Lingu.Errors
{
    public class TreeException : Exception
    {
        public TreeException()
        {
        }

        public TreeException(string message) : base(message)
        {
        }

        public TreeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TreeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
