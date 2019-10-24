
using Lipeg.Runtime;

#nullable enable

namespace Lipeg.SDK.Tree
{
    public class Quantifier
    {
        private Quantifier(ILocation location, int min, int? max, Expression? delimiter)
        {
            Location = location;
            Min = min;
            Max = max;

            if (delimiter != null)
            {
                SequenceExpression? sequenceExpression;
                if ((sequenceExpression = delimiter as SequenceExpression) == null || sequenceExpression.Sequence.Count != 0)
                {
                    Delimiter = delimiter;
                }
            }
        }
        public ILocation Location { get; }
        public int Min { get; }
        public int? Max { get; }
        public Expression? Delimiter { get; }

        public static Quantifier From(ILocation location, int min, int? max, Expression? delimiter = null)
        {
            return new Quantifier(location, min, max, delimiter);
        }
    }
}
