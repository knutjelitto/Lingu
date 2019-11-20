using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class InlineExpression : Expression
    {

        private InlineExpression(ILocated located, IRule inlineRule)
            : base(located)
        {
            InlineRule = inlineRule;
            Rule = inlineRule;
        }

        public IRule InlineRule { get; }
        public IRule Rule { get; set; }

        public static InlineExpression From(ILocated located, IRule rule)
        {
            return new InlineExpression(located, rule);
        }
    }
}
