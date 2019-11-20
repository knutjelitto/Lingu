using System.Collections.Generic;
using System.IO;

namespace Lipeg.Runtime
{
    public interface ICompileResult
    {
        void SetSource(Source source);
        Source GetSource();

        bool HasErrors { get; }
        bool ShouldStop { get; }
        bool IsFatal { get; }

        void AddError(IMessage error);
        IReadOnlyList<IMessage> Errors { get; }

        bool Report(TextWriter writer);
    }
}
