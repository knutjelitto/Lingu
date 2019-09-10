using Lingu.Automata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public abstract class Expression : Node, IExpression
    {
        public abstract FA GetFA();

        public abstract IEnumerable<IExpression> Children { get; }

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
