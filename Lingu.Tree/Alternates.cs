using Lingu.Automata;
using Lingu.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class Alternates : Expression
    {
        public Alternates(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }

        public override FA GetNfa()
        {
            var nfa = Expressions.First().GetNfa();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Or(expr.GetNfa());
            }
            return nfa;
        }

        public override void Dump(Indentable output, bool top)
        {
            if (top)
            {
                foreach (var expression in Expressions)
                {
                    output.Write("| ");
                    expression.Dump(output, !(expression is Alternates));
                    output.WriteLine();
                }
            }
            else
            {
                output.Write("(");
                var more = false;
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
