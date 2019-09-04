using Lingu.Commons;

namespace Lingu.Tree
{
    public abstract class Definition : NamedNode
    {
        public Definition(bool generated, AtomName name, Expression expression)
            : base(name)
        {
            IsGenerated = generated;
            Expression = expression;
        }

        public bool IsGenerated { get; }
        public Expression Expression { get; }

        public int UseCount { get; private set; }

        public void Use()
        {
            UseCount += 1;
        }

        public override void Dump(Indentable output, bool top)
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
