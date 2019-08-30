using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public class RuleSub : RuleExpression
    {
        public AtomName Name { get; }
        public RuleExpression Expression { get; }

        public RuleSub(AtomName name, RuleExpression expression)
        {
            Name = name;
            Expression = expression;
        }
    }
}
