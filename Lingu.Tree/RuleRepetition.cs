using System;

namespace Lingu.Tree
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
