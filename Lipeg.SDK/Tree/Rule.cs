namespace Lipeg.SDK.Tree
{
    public class Rule : IRule
    {
        private Rule(Identifier identifier, Expression expression)
        {
            Identifier = identifier;
            if (expression is SequenceExpression sequence && sequence.Sequence.Count == 1)
            {
                Expression = sequence.Sequence[0];
            }
            else if (expression is ChoiceExpression choice && choice.Choices.Count == 1)                
            {
                Expression = choice.Choices[0];
            }
            else
            {
                Expression = expression;
            }
        }
        public Identifier Identifier { get; private set; }
        public Expression Expression { get; }
        public static IRule From(Identifier identifier, Expression expression) => new Rule(identifier, expression);

        public override string ToString()
        {
            return Identifier.Name;
        }
    }
}
