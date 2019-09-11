using Lingu.Commons;
using Lingu.Grammars;
using System.Diagnostics;

namespace Lingu.Tree
{
    public sealed class TreeNonterminal : Nonterminal
    {
        public TreeNonterminal(bool isGenerated, string name, IExpression expression)
            : base(name)
        {
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public TreeNonterminal(string name, IExpression expression)
            : this(false, name, expression)
        {
        }

        public IExpression Expression { get; set; }

        public override void Dump(IWriter output, bool top)
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
