namespace Lingu.Tree
{
    public class RuleText : RuleExpression
    {
        public RuleText(LitText text)
        {
            Text = text;
        }

        public LitText Text { get; }
    }
}
