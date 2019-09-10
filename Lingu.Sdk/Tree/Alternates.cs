using Lingu.Automata;
using Lingu.Commons;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class Alternates : IExpression
    {
        public Alternates(IEnumerable<IExpression> expressions)
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
                nfa = nfa.Or(expr.GetFA());
            }
            return nfa;
        }

        public void Dump(IWriter output, bool top)
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
