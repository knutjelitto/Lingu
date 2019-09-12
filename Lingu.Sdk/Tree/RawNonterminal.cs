using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class RawNonterminal : Nonterminal
    {
        public RawNonterminal(bool isGenerated, string name, IExpression expression)
            : base(name)
        {
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public RawNonterminal(string name, IExpression expression)
            : this(false, name, expression)
        {
        }

        public IExpression Expression { get; set; }

        public override void Dump(IndentWriter output, bool top)
        {
            output.Indend($"{Name}", () =>
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
