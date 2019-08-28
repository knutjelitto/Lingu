using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class TerminalSequence : TerminalExpression
    {
        public TerminalSequence(IEnumerable<TerminalExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<TerminalExpression> Expressions { get; }
    }
}
