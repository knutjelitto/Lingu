using Lipeg.SDK.Output;
using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface IParser
    {
        string Name { get; }
        IResult Parse(ICursor cursor);

        void Dump(int level, IWriter writer);
    }
}
