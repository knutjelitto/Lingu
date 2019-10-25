using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Rule
    {
        private Rule(Identifier identifier, IReadOnlyList<Identifier> flags, Expression expression)
        {
            Identifier = identifier;
            Flags = flags;
            Expression = expression;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }
        public IReadOnlyList<Identifier> Flags { get; }

        public static Rule From(Identifier identifier, IReadOnlyList<Identifier> flags, Expression expression)
        {
            return new Rule(identifier, flags, expression);
        }
    }
}
