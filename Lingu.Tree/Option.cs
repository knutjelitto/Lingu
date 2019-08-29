namespace Lingu.Tree
{
    public class Option : NamedNode
    {
        public Option(AtomName name, LitString litString)
            : base(name)
        {
            LitString = litString;
        }

        public LitString LitString { get; }
    }
}
