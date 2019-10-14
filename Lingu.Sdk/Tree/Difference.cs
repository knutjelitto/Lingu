using System.Collections.Generic;

using Lingu.Automata;
using Lingu.Output;

#nullable enable

namespace Lingu.Tree
{
    public class Difference : Node, IExpression
    {
        public Difference(IExpression expression1, IExpression expression2)
        {
            Expression1 = expression1;
            Expression2 = expression2;
        }

        public IExpression Expression1 { get; }
        public IExpression Expression2 { get; }


        public IEnumerable<IExpression> Children => new [] {Expression1, Expression2};

        public FA GetFA()
        {
            var nfa1 = Expression1.GetFA();
            var nfa2 = Expression2.GetFA();

            var cross = nfa1.ToDfa().Difference(nfa2.ToDfa());

            return cross;
        }

        public override void Dump(IndentWriter output)
        {
            output.Write("(");
            Expression1.Dump(output);
            output.Write(" - ");
            Expression2.Dump(output);
            output.Write(")");
        }
    }
}
