using Lingu.Automata;
using Lingu.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Sdk.Tree
{
    public class Sequence : Expression
    {
        public Sequence(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }
        public override IEnumerable<Expression> Children => throw new System.NotImplementedException();

        public override FA GetFA()
        {
            var nfa = Expressions.First().GetFA();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Concat(expr.GetFA());
            }
            return nfa;
        }

        public override void Dump(IWriter output, bool top)
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
    }
}
