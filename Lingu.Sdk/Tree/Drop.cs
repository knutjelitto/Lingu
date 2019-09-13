using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;

namespace Lingu.Tree
{
    public class Drop : Node, IExpression
    {
        public Drop(IExpression expression)
        {
            Expression = expression;
        }

        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public IExpression Expression { get; }

        public FA GetFA()
        {
            throw new NotImplementedException();
        }
    }
}
