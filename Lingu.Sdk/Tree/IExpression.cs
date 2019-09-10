using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public interface IExpression : ICanDump
    {
        FA GetFA();

        IEnumerable<IExpression> Children { get; }

        TreeActionKind Action { get; set; }
    }
}
