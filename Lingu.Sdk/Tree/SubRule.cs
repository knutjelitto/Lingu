using Lingu.Commons;

namespace Lingu.Tree
{
    public class SubRule : Node
    {
        public SubRule(Name name, Expression expression)
        {
            Name = name;
            Expression = expression;
        }

        public Name Name { get; }
        public Expression Expression { get; }

        public override void Dump(IWriter output, bool top)
        {
            output.Write("{");
            Name.Dump(output, false);
            output.Write(": ");
            Expression.Dump(output, !(Expression is Alternates));
            output.Write("}");
        }
    }
}
