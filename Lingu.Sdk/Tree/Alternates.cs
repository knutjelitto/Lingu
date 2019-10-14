using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public class Alternates : Node, IExpression
    {
        public Alternates(IEnumerable<IExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public Alternates(IReadOnlyList<IExpression> expressions)
        {
            Expressions = expressions;
        }

        public Alternates(params IExpression[] expressions)
            : this((IReadOnlyList<IExpression>)expressions)
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

        public override void Dump(IndentWriter writer)
        {
            var more = false;
            writer.Write("(");
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    writer.Write(" | ");
                }
                expression.Dump(writer);
                more = true;
            }
            writer.Write(")");
        }
    }
}
