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
    }
}
