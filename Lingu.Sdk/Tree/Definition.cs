using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public abstract class Definition : Symbol
    {
        public Definition(bool isGenerated, string name, IExpression expression)
            : base(name)
        {
            IsGenerated = isGenerated;
            Expression = expression;
        }

        public bool IsGenerated { get; }
        public IExpression Expression { get; }

        public int UseCount { get; private set; }

        public void Use()
        {
            UseCount += 1;
        }

        public override string ToString()
        {
            return $"{Name} -> ...";
        }

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
