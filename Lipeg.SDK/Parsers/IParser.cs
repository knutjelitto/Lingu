using Lipeg.SDK.Output;
using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface IParser
    {
        string Kind { get; }
        IResult Parse(IContext context);
        void Dump(int level, IWriter writer);
    }
}
