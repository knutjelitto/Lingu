namespace Lingu.Sdk.Tree
{
    public abstract class NamedNode : Node, INamed
    {
        public NamedNode(AtomName name)
        {
            Name = name;
        }

        public AtomName Name { get; }
    }
}
