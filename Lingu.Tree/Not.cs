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

        public override Nfa GetNfa()
        {
            var dfa = Expression.GetNfa().ToDfa().Minimize().Complete();
            throw new NotImplementedException();
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write("~");
            Expression.Dump(output, false);
        }
    }
}
