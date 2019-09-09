using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Reference : Expression
    {
        public Reference(Name name, ReferenceKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public Name Name { get; }
        public ReferenceKind Kind { get; }
        public Definition Definition { get; private set; }
        public override IEnumerable<Expression> Children => Enumerable.Empty<Expression>();

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
