using System;
using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalSequence : TerminalExpression
    {
        public TerminalSequence(IEnumerable<TerminalExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<TerminalExpression> Expressions { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.Write("| ");
                var more = false;
                foreach (var expression in Expressions)
                {
                    if (more)
                    {
                        output.Write(" ");
                    }
                    expression.Dump(output, false);
                    more = true;
                }
                output.WriteLine("");
            }
            else
            {
                output.Write("(");
                var more = false;
                foreach (var expression in Expressions)
                {
                    if (more)
                    {
                        output.Write(" ");
                    }
                    expression.Dump(output, false);
                    more = true;
                }
                output.Write(")");
            }
        }
    }
}
