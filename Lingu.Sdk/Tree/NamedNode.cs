namespace Lingu.Tree
{
    public abstract class NamedNode : Node, INamed
    {
        public NamedNode(Name name)
        {
            Name = name;
        }

        public Name Name { get; }
    }
}
