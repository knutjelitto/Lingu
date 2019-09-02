using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomRange : Atom
    {
        public AtomRange(Expression from, Expression to)
        {
            From = from;
            To = to;
        }

        public Expression From { get; }
        public Expression To { get; }

        public override Nfa GetNfa()
        {
            var dfa1 = From.GetNfa().ToDfa().Minimize();
            var dfa2 = To.GetNfa().ToDfa().Minimize();

            throw new System.NotImplementedException();
        }

        public override void Dump(Indentable output, bool top)
        {
            if (!top) output.Write("(");
            From.Dump(output, false);
            output.Write(" .. ");
            To.Dump(output, false);
            if (!top) output.Write(")");
        }
    }
}
