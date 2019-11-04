using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lipeg.Runtime
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException(string message)
            : base(message)
        {
        }
    }
}
