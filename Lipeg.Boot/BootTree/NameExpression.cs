using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class NameExpression : Expression
    {
        private NameExpression(Identifier identifier)
        {
            Identifier = identifier;
        }
        public Identifier Identifier { get; }

        public static NameExpression From(Identifier identifier)
        {
            return new NameExpression(identifier);
        }
    }
}
