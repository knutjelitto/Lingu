namespace Lingu.Tree
{
    public abstract class NamedNode : Node
    {
        public NamedNode(AtomName name)
        {
            Name = name;
        }

        public AtomName Name { get; }
    }
}
