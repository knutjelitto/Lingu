using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Sequence : Node, IExpression
    {
        public Sequence(IEnumerable<IExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<IExpression> Expressions { get; }
        public IEnumerable<IExpression> Children => Expressions;

        public FA GetFA()
        {
            var nfa = Expressions.First().GetFA();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Concat(expr.GetFA());
            }
            return nfa;
        }

        public override void Dump(IndentWriter output, bool top)
        {
            if (!top) output.Write("(");
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
            if (!top) output.Write(")");
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
