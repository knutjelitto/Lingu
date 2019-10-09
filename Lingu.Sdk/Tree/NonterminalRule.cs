using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class NonterminalRule : Nonterminal
    {
        private NonterminalRule(string name, bool lift, IEnumerable<IExpression> alternates)
            : base(name)
        {
            Alternates = alternates.ToArray();
        }

        public IReadOnlyList<IExpression> Alternates { get; set; }

        public static NonterminalRule From(string name, bool promote, IExpression expression)
        {
            if (expression is Alternates alternates)
            {
                return new NonterminalRule(name, promote, alternates.Expressions);
            }
            return new NonterminalRule(name, promote, Enumerable.Repeat(expression, 1));
        }

        public void Dump(IndentWriter output)
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
