namespace Lipeg.Runtime
{
    public class MessageWarning : Message
    {
        public MessageWarning(MessageCode code, string message)
            : base(MessageSeverity.Warning, code, message)
        {
        }
        public MessageWarning(MessageCode code, ILocated located)
            : base(MessageSeverity.Warning, code, located)
        {
        }
    }
}
