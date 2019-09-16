using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class SubRule : Node, IExpression
    {
        public SubRule(Name name, IExpression expression)
        {
            Name = name;
            Expression = expression;
        }

        public Name Name { get; }
        public IExpression Expression { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);
        public Nonterminal Nonterminal { get; set; }

        public override void Dump(IndentWriter writer)
        {
            writer.Write($"{{{Name}: ");
            Expression.Dump(writer);
            writer.Write($"}}");
        }

        public FA GetFA()
        {
            throw new NotImplementedException();
        }
    }
}
