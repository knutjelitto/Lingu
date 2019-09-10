using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Not : Node, IExpression
    {
        public Not(IExpression expression)
        {
            Expression = expression;
        }

        public IExpression Expression { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public FA GetFA()
        {
            //return Expression.GetNfa().ToDfa().Minimize().Complete().Negate();
            return Expression.GetFA().ToDfa().Complete().Negate().RemoveDead().ToNfa();
        }

        public override void Dump(IWriter output, bool top)
        {
            output.Write("~");
            Expression.Dump(output, false);
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
