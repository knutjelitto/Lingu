using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public sealed class TerminalDefinition : Terminal
    {
        public TerminalDefinition(bool isGenerated, Name name, Expression expression)
            : base(name.Name)
        {
            Id = -1;
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public TerminalDefinition(Name name, Expression expression)
            : this(false, name, expression)
        {
        }

        public int UseCount { get; private set; }
        public Expression Expression { get; }
        public byte[] Bytes { get; set; }
        public void Use()
        {
            UseCount += 1;
        }

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
