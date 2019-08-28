using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class TerminalDifference : TerminalExpression
    {
        public TerminalDifference(IEnumerable<TerminalExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<TerminalExpression> Expressions { get; }
    }
}
