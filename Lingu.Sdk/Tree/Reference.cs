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
        public TreeActionKind Action { get; set; }

        public void ResolveTo(TreeTerminal definition)
        {
            Definition = definition;
            definition.Use();
        }

        public void ResolveTo(TreeNonterminal definition)
        {
            Definition = definition;
            definition.Use();
        }

        public FA GetFA()
        {
            return ((TreeTerminal)Definition).Expression.GetFA();
        }

        public override void Dump(IWriter output, bool top)
        {
            this.ActionPrefix(output);
            if (Definition is TreeTerminal terminalDefinition && terminalDefinition.IsGenerated)
            {
                terminalDefinition.Expression.Dump(output, top);
            }
            else if (Definition is TreeNonterminal non && non.IsEmbedded)
            {
                output.Write($"{{{Definition.Name}: ");
                non.Expression.Dump(output, top);
                output.Write("}");
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
