using Pegasus.Common;

#nullable enable

namespace Lipeg.Boot.BootTree
{
    public class Quantifier
    {
        private Quantifier(Cursor start, Cursor end, int min, int? max, Expression? delimiter)
        {
            Start = start;
            End = end;
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
        public Cursor Start { get; }
        public Cursor End { get; }
        public int Min { get; }
        public int? Max { get; }
        public Expression? Delimiter { get; }

        public static Quantifier From(Cursor start, Cursor end, int min, int? max, Expression? delimiter = null)
        {
            return new Quantifier(start, end, min, max, delimiter);
        }
    }
}
