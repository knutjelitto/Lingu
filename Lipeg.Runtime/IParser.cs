using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface IParser : IEnumerable<IParser>
    {
        string Name { get; }
        IResult Parse(ICursor cursor);
    }
}
