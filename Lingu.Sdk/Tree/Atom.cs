using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public abstract class Atom : IExpression
    {
        public Atom()
        {
        }

        public virtual IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();
        public Repeat Repeat { get; set; }

        public abstract void Dump(IndentWriter output, bool top);
        public abstract FA GetFA();

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
