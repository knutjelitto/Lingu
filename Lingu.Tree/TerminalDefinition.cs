using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class TerminalDefinition : TerminalExpression
    {
        public TerminalDefinition(IEnumerable<TerminalExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<TerminalExpression> Expressions { get; }
    }
}
