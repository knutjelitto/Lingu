using System.Collections.Generic;
using System.Linq;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Difference : IExpression
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

            var cross = nfa1.ToDfa().Substract(nfa2.ToDfa());

            return cross; ;
        }

        public void Dump(IWriter output, bool top)
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

        public IEnumerator<IExpression> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
