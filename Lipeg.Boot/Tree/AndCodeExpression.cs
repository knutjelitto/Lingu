using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class AndCodeExpression : Expression
    {
        private AndCodeExpression(CodeSpan code)
        {
            Code = code;
        }
        public CodeSpan Code { get; }

        public static AndCodeExpression From(CodeSpan code)
        {
            return new AndCodeExpression(code);
        }
    }
}
