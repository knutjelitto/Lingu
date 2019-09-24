using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Difference : Node, IExpression
    {
        public Difference(IEnumerable<IExpression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<IExpression> Expressions { get; }
        public IEnumerable<IExpression> Children => Expressions;

        public FA GetFA()
        {
            if (Expressions.Count != 2)
            {
                throw new System.NotImplementedException();
            }

            var nfa1 = Expressions[0].GetFA();
            var nfa2 = Expressions[1].GetFA();

            var cross = nfa1.ToDfa().Difference(nfa2.ToDfa());

            return cross; ;
        }

        public override void Dump(IndentWriter output)
        {
            output.Write("(");
            var more = false;
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    output.Write(" - ");
                }
                expression.Dump(output);
                more = true;
            }
            output.Write(")");
        }
    }
}
