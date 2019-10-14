using Lingu.Grammars;

namespace Lingu.Tree
{
    public sealed class TerminalRule : Terminal
    {
        public static readonly TerminalRule Nope = new TerminalRule("$nope$", new Nope());

        private TerminalRule(string name, IExpression expression)
            : base(name)
        {
            Expression = expression;
        }

        public IExpression Expression { get; }

        public static TerminalRule From(string name, IExpression expression)
        {
            return new TerminalRule(name, expression);
        }
    }
}
