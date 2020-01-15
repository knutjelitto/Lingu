using Lipeg.Runtime;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Parsers
{
    public interface ICombiParser : IParser
    {
        string Kind { get; }
        void Dump(int level, IWriter writer);
    }
}
