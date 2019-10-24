using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class Rule
    {
        private Rule(Identifier identifier, Expression expression, IEnumerable<Identifier>? flags)
        {
            Identifier = identifier;
            Expression = expression;
            Flags = flags;
        }
        public Identifier Identifier { get; }
        public Expression Expression { get; }
        public IEnumerable<Identifier>? Flags { get; }

        public static Rule From(Identifier identifier, Expression expression, IEnumerable<Identifier>? flags)
        {
            return new Rule(identifier, expression, flags);
        }
    }
}
