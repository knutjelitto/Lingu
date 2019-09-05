using System.Collections.Generic;
using System.Linq;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Sdk.Tree
{
    public class Difference : Expression
    {
        public Difference(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }
        public override IEnumerable<Expression> Children => Expressions;

        public override FA GetFA()
        {
            if (Expressions.Count != 2)
            {
                throw new System.NotImplementedException();
            }

            var nfa1 = Expressions[0].GetFA();
            var nfa2 = Expressions[1].GetFA();

            var cross = nfa1.ToDfa().Substract(nfa2.ToDfa());

            return cross; ;
        }

        public override void Dump(IWriter output, bool top)
        {
            if (!top) output.Write("(");
            var more = false;
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    output.Write(" - ");
                }
                expression.Dump(output, false);
                more = true;
            }
            if (!top) output.Write(")");
        }
    }
}
