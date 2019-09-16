using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class RawNonterminal : Nonterminal
    {
        private RawNonterminal(string name, bool lift, IEnumerable<IExpression> alternates)
            : base(name)
        {
            Alternates = alternates.ToArray();
            Lift = lift ? LiftKind.User : LiftKind.None;
        }

        public IReadOnlyList<IExpression> Alternates { get; set; }

        public static RawNonterminal From(string name, bool promote, IExpression expression)
        {
            if (expression is Alternates alternates)
            {
                return new RawNonterminal(name, promote, alternates.Expressions);
            }
            return new RawNonterminal(name, promote, Enumerable.Repeat(expression, 1));
        }

        public override void Dump(IndentWriter output)
        {
            output.Indend($"{Name}", () =>
            {
                bool more = false;
                foreach (var expression in Alternates)
                {
                    if (more)
                    {
                        output.Write("| ");
                    }
                    else
                    {
                        output.Write(": ");
                    }
                    more = true;

                    expression.Dump(output);
                    output.WriteLine();
                }
                output.WriteLine(";");
            });
        }
    }
}
