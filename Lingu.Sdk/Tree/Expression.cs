using Lingu.Automata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public abstract class Expression : Node, IEnumerable<Expression>
    {
        public abstract FA GetFA();

        public abstract IEnumerable<Expression> Children { get; }

        public IEnumerator<Expression> GetEnumerator()
        {
            return Children.GetEnumerator(); ;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); ;
        }
    }
}
