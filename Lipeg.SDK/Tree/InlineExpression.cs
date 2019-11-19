using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class InlineExpression : Expression
    {

        private InlineExpression(ILocated located, Rule inlineRule)
            : base(located)
        {
            InlineRule = inlineRule;
        }

        public Rule InlineRule { get; }

        public static InlineExpression From(ILocated located, Rule rule)
        {
            return new InlineExpression(located, rule);
        }
    }
}
