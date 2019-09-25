using System;

using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class RawTerminal : Terminal
    {
        public static readonly RawTerminal Nope = new RawTerminal("$nope$", new Nope());

        public RawTerminal(string name, IExpression expression)
            : base(name)
        {
            Expression = expression;
        }

        public IExpression Expression { get; }
    }
}
