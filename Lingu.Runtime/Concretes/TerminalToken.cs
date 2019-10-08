using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class TerminalToken : Token, ITerminalToken
    {
        public TerminalToken(ITerminal terminal, ILocation location)
            : base(terminal)
        {
            Location = location;
        }

        public ILocation Location { get; }
        public string Value => Location.GetText();
    }
}
