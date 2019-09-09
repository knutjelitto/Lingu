using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Reference : Expression
    {
        public Reference(Symbol name, ReferenceKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public Symbol Name { get; }
        public ReferenceKind Kind { get; }
        public Symbol Definition { get; private set; }
        public override IEnumerable<Expression> Children => Enumerable.Empty<Expression>();

        public void ResolveTo(TerminalDefinition definition)
        {
            Definition = definition;
            definition.Use();
        }

        public void ResolveTo(RuleDefinition definition)
        {
            Definition = definition;
            definition.Use();
        }

        public override FA GetFA()
        {
            return ((TerminalDefinition)Definition).Expression.GetFA();
        }

        public override void Dump(IWriter output, bool top)
        {
            if (Definition is TerminalDefinition terminalDefinition && terminalDefinition.IsGenerated)
            {
                terminalDefinition.Expression.Dump(output, top);
            }
            else
            {
                Name.Dump(output, top);
            }
        }
    }
}
