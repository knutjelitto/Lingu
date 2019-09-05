using Lingu.Automata;
using Lingu.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Sdk.Tree
{
    public class Alternates : Expression
    {
        public Alternates(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }
        public override IEnumerable<Expression> Children => Expressions;

        public override FA GetFA()
        {
            var nfa = Expressions.First().GetFA();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Or(expr.GetFA());
            }
            return nfa;
        }

        public override void Dump(IWriter output, bool top)
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
