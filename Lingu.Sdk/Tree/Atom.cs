using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public abstract class Atom : IExpression
    {
        public Atom()
        {
            Action = TreeActionKind.None;
        }

        public virtual IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();
        public TreeActionKind Action { get; set; }

        public abstract void Dump(IWriter output, bool top);
        public abstract FA GetFA();

        public IEnumerator<IExpression> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}
