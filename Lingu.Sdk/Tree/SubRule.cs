using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;

namespace Lingu.Tree
{
    public class SubRule : Node, IExpression
    {
        public SubRule(Name name, IExpression expression)
        {
            Name = name;
            Expression = expression;
        }

        public Name Name { get; }
        public IExpression Expression { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public FA GetFA()
        {
            throw new NotImplementedException();
        }
    }
}
