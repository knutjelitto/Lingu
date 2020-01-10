using System.Collections.Generic;
using System.IO;

namespace Lipeg.Runtime
{
    public interface ICompileResult
    {
        bool HasAny { get; }
        bool HasErrors { get; }
        bool ShouldStop { get; }
        bool IsFatal { get; }

        void AddError(IMessage error);
        IReadOnlyList<IMessage> Errors { get; }

        bool Report(TextWriter writer);
    }
}
