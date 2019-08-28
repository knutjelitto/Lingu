using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class RuleRepetition : RuleExpression
    {
        public RuleRepetition(RuleExpression expression, int? min = null, int? max = null)
        {
            Expression = expression;
            Min = min;
            Max = max;
        }

        public RuleExpression Expression { get; }
        public Int32? Min { get; }
        public Int32? Max { get; }
    }
}
