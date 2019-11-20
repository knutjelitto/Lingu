using System.IO;

namespace Lipeg.Runtime
{
    public interface IMessage
    {
        MessageSeverity Severity { get; }
        MessageCode Code { get; }
        string Msg { get; }
        ILocation Location { get; }

        void Report(TextWriter writer);
    }
}
