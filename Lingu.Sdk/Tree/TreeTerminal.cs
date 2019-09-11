using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public sealed class TreeTerminal : Terminal
    {
        public TreeTerminal(bool isGenerated, string name, IExpression expression)
            : base(name)
        {
            Id = -1;
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public TreeTerminal(string name, IExpression expression)
            : this(false, name, expression)
        {
        }

        public IExpression Expression { get; }
        public byte[] Bytes { get; set; }

        public override void Dump(IWriter output, bool top)
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
