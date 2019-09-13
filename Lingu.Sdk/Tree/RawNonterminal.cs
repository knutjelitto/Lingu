using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class RawNonterminal : Nonterminal
    {
        public RawNonterminal(string name, IEnumerable<IExpression> alternates)
            : base(name)
        {
            Expressions = alternates.ToArray();
        }

        public IReadOnlyList<IExpression> Expressions { get; set; }

        public override void Dump(IndentWriter output, bool top)
        {
            output.Indend($"{Name}", () =>
            {
                bool more = false;
                foreach (var expression in Expressions)
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

                    expression.Dump(output, top);
                    output.WriteLine();
                }
                output.WriteLine(";");
            });
        }
    }
}
