using System;
using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalDefinition : TerminalExpression
    {
        public TerminalDefinition(IEnumerable<TerminalExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<TerminalExpression> Expressions { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                foreach (var expression in Expressions)
                {
                    expression.Dump(output, top);
                }
            }
        }
    }
}
