using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Terminals : Node
    {
        public Terminals(IEnumerable<TerminalRule> rules)
        {
            Rules = rules.ToArray(); ;
        }

        public IReadOnlyList<TerminalRule> Rules { get; }

        public override void Dump(Indentable output, bool top)
        {
            output.Block("terminals", () =>
            {
                foreach (var option in Rules)
                {
                    option.Dump(output, top);
                }
            });
        }

    }
}
