using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public class TerminalNot : TerminalExpression
    {
        public TerminalNot(TerminalExpression expression)
        {
            Expression = expression;
        }

        public TerminalExpression Expression { get; }
    }
}
