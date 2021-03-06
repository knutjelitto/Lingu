using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public abstract class Atom : IExpression
    {
        public Atom()
        {
        }

        public virtual IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();
        //public Repeat Repeat { get; set; }

        public abstract void Dump(IndentWriter writer);
        public abstract FA GetFA();

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
