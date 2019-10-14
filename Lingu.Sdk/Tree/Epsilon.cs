using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Output;

#nullable enable

namespace Lingu.Tree
{
    public sealed class Epsilon : Node, IExpression
    {
        public IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();

        public override void Dump(IndentWriter output)
        {
            output.Write("ε");
        }

        public FA GetFA()
        {
            throw new System.NotImplementedException();
        }
    }
}
