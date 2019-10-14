using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public class Sequence : Node, IExpression
    {
        public Sequence(IEnumerable<IExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public Sequence(params IExpression[] expressions)
            : this(expressions.AsEnumerable())
        {
        }

        public IReadOnlyList<IExpression> Expressions { get; }
        public IEnumerable<IExpression> Children => Expressions;

        public FA GetFA()
        {
            var nfa = Expressions.First().GetFA();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.And(expr.GetFA());
            }
            return nfa;
        }

        public override void Dump(IndentWriter output)
        {
            output.Write("(");
            var more = false;
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    output.Write(" ");
                }
                expression.Dump(output);
                more = true;
            }
            output.Write(")");
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
