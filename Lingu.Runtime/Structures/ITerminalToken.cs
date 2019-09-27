using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ITerminalToken : IToken
    {
        ITerminal Terminal { get; }
        ILocation Location { get; }
    }
}
