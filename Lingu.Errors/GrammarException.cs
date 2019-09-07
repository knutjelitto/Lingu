using System;
using System.Runtime.Serialization;

namespace Lingu.Errors
{
    public class GrammarException : Exception
    {
        public GrammarException()
        {
        }

        public GrammarException(string message) : base(message)
        {
        }

        public GrammarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GrammarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
