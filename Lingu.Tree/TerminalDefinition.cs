using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public sealed class TerminalDefinition : Definition
    {
        public TerminalDefinition(bool generated, AtomName name, Expression expression)
            : base(generated, name, expression)
        {
        }

        public TerminalDefinition(AtomName name, Expression expression)
            : base(false, name, expression)
        {
        }
    }
}
