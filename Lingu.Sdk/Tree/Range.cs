using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Range : Atom
    {
        public Range(IExpression from, IExpression to)
        {
            From = from;
            To = to;
        }

        public IExpression From { get; }
        public IExpression To { get; }

        public override FA GetFA()
        {
            if (From.IsSingleCodePoint() && To.IsSingleCodePoint())
            {
                return FA.From(From.GetSingleCodePoint(), To.GetSingleCodePoint());
            }

            throw new System.NotImplementedException();
        }

        public override void Dump(IndentWriter output, bool top)
        {
            if (!top) output.Write("(");
            From.Dump(output, false);
            output.Write(" .. ");
            To.Dump(output, false);
            if (!top) output.Write(")");
        }
    }
}
