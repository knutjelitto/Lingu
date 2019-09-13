using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;

namespace Lingu.Tree
{
    public class TreeAction : Node, IExpression
    {
        public TreeAction(ActionKind kind, IExpression expression)
        {
            Kind = kind;
            Expression = expression;
        }

        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public ActionKind Kind { get; }
        public IExpression Expression { get; }

        public FA GetFA()
        {
            throw new NotImplementedException();
        }
    }
}
