using System;

using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class RawTerminal : Terminal
    {
        public RawTerminal(string name, IExpression expression)
            : base(name)
        {
            Expression = expression;
        }

        public IExpression Expression { get; }

        public override void Dump(IndentWriter output)
        {
            throw new NotImplementedException();
        }
    }
}
