using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface ITerminalToken : IToken
    {
        ILocation Location { get; }
        string Value { get; }
    }
}
