using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public interface IGrammarAttributes
    {
        Rule Start { get; }
        Rule Spacing { get; }
        IParser Parser { get; }

        bool SetStart(Rule rule);
        bool SetSpacing(Rule rule);
        bool SetParser(IParser parser);
    }
}
