using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Sdk.Tree
{
    public class Reference : Expression
    {
        public Reference(AtomName name, ReferenceKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public AtomName Name { get; }
        public ReferenceKind Kind { get; }
        public Definition Definition { get; private set; }

        public void ResolveTo(Definition definition)
        {
            Definition = definition;
            definition.Use();
        }

        public override FA GetFA()
        {
            return Definition.Expression.GetFA();
        }

        public override void Dump(IWriter output, bool top)
        {
            if (Definition is TerminalDefinition && Definition.IsGenerated)
            {
                Definition.Expression.Dump(output, top);
            }
            else
            {
                Name.Dump(output, top);
            }
        }
    }
}
