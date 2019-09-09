using Lingu.Commons;
using Lingu.Grammars;
using System.Diagnostics;

namespace Lingu.Tree
{
    public sealed class RuleDefinition : Nonterminal
    {
        public RuleDefinition(bool isGenerated, Name name, Expression expression)
            : base(name.Name)
        {
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public RuleDefinition(Name name, Expression expression)
            : this(false, name, expression)
        {
        }

        public bool IsGenerated { get; }
        public Expression Expression { get; }
        public int UseCount { get; private set; }
        public void Use()
        {
            UseCount += 1;
        }

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
