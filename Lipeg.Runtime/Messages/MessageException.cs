using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public class MessageException : Exception
    {
        public MessageException(Message msg)
        {
            Msg = msg;
        }
        public Message Msg { get; }

    }
}
