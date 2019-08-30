using System.IO;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Grammar : Node
    {
        public Grammar(AtomName name, Options options, Terminals terminals, Rules rules)
        {
            Name = name;
            Options = options;
            Terminals = terminals;
            Rules = rules;
        }

        public AtomName Name { get; }
        public Options Options { get; }
        public Terminals Terminals { get; }
        public Rules Rules { get; }

        public void Dump(TextWriter writer)
        {
            var output = new Indentable();

            this.Dump(output, true);

            output.Dump(writer);
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Block($"grammar {Name}", () =>
            {
                Options.Dump(output, top);
                Terminals.Dump(output, top);
                Rules.Dump(output, top);
            });
        }
    }
}
