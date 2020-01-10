using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lipeg.Runtime
{
    public class InternalNullException : InternalErrorException
    {
        public InternalNullException()
            : base("can't be")
        {
        }
    }
}
