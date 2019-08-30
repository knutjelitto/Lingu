using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalNot : TerminalExpression
    {
        public TerminalNot(TerminalExpression expression)
        {
            Expression = expression;
        }

        public TerminalExpression Expression { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.Write("! ");
            }
            output.Write("~");
            Expression.Dump(output, false);
            if (top)
            {
                output.WriteLine("");
            }
        }
    }
}
