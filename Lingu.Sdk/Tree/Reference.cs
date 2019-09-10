using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Reference : Symbol, IExpression
    {
        public Reference(Symbol name, ReferenceKind kind)
            : base(name.Name)
        {
            Kind = kind;
        }

        public ReferenceKind Kind { get; }
        public Symbol Definition { get; private set; }
        public IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();

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

        public FA GetFA()
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
                output.Write(Name);
            }
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
