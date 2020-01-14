using System.Collections.Generic;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public abstract class ClassPartExpression : Expression
    {
        protected internal ClassPartExpression(ILocated located)
            : base(located)
        {
        }

        public abstract IEnumerable<int> Values { get; }
    }
}
