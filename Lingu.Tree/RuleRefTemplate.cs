namespace Lingu.Tree
{
    public class RuleRefTemplate : RuleRef
    {
        public RuleRefTemplate(AtomName name, RuleArguments arguments)
            : base(name)
        {
            Arguments = arguments;
        }

        public RuleArguments Arguments { get; }
    }
}
