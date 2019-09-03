using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Not : Expression
    {
        public Not(Expression expression)
        {
            Expression = expression;
        }

        public Expression Expression { get; }

        public override FA GetNfa()
        {
            //return Expression.GetNfa().ToDfa().Minimize().Complete().Negate().ToNfa();
            return Expression.GetNfa().ToDfa();
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write("~");
            Expression.Dump(output, false);
        }
    }
}
