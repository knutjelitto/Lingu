using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Range : Atom
    {
        public Range(Expression from, Expression to)
        {
            From = from;
            To = to;
        }

        public Expression From { get; }
        public Expression To { get; }

        public override FA GetFA()
        {
            if (From.IsSingleCodePoint() && To.IsSingleCodePoint())
            {
                return FA.From(From.GetSingleCodePoint(), To.GetSingleCodePoint());
            }

            throw new System.NotImplementedException();
        }

        public override void Dump(IWriter output, bool top)
        {
            if (!top) output.Write("(");
            From.Dump(output, false);
            output.Write(" .. ");
            To.Dump(output, false);
            if (!top) output.Write(")");
        }
    }
}
