using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Alternates : Node, IExpression
    {
        public Alternates(IEnumerable<IExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public Alternates(params IExpression[] expressions)
            : this(expressions.AsEnumerable())
        {
        }

        public IReadOnlyList<IExpression> Expressions { get; private set; }
        public IEnumerable<IExpression> Children => Expressions;

        public void Combine(IEnumerable<IExpression> expressions)
        {
            Expressions = Expressions.Concat(expressions).ToArray();
        }

        public void Combine(IExpression expression)
        {
            Expressions = Expressions.Concat(Enumerable.Repeat(expression, 1)).ToArray();
        }

        public FA GetFA()
        {
            var nfa = Expressions.First().GetFA();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Or(expr.GetFA());
            }
            return nfa;
        }

        public override void Dump(IndentWriter output, bool top)
        {
            var more = false;
            if (top)
            {
                foreach (var expression in Expressions)
                {
                    output.Write(more ? "| " : ": ");
                    expression.Dump(output, !(expression is Alternates));
                    output.WriteLine();
                    more = true;
                }
            }
            else
            {
                output.Write("(");
                foreach (var expression in Expressions)
                {
                    if (more)
                    {
                        output.Write(" | ");
                    }
                    expression.Dump(output, !(expression is Alternates));
                    more = true;
                }
                output.Write(")");
            }
        }
    }
}
