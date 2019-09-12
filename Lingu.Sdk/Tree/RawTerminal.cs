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

        public override void Dump(IndentWriter output, bool top)
        {
            var f = IsFragment ? "fragment " : "";
            output.Indend($"{f}{Name} // ({Id})", () =>
            {
                if (Expression is Alternates)
                {
                    Expression.Dump(output, true);
                }
                else
                {
                    output.Write(": ");
                    Expression.Dump(output, true);
                    output.WriteLine();
                }
                output.WriteLine(";");
            });
        }
    }
}
