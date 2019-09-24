using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Conlex : IConlex
    {
        public Conlex(ITerminalToken token)
        {
            Token = token;
        }

        public ITerminalToken Token { get; }
    }
}
