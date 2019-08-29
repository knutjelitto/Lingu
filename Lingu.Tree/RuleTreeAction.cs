namespace Lingu.Tree
{
    public class RuleTreeAction : RuleExpression
    {
        public enum TreeAction
        {
            Drop,
            Promote
        }

        public RuleTreeAction(RuleExpression expression, TreeAction action)
        {
            Expression = expression;
            Action = action;
        }

        public RuleExpression Expression { get; }
        public TreeAction Action { get; }
    }
}
