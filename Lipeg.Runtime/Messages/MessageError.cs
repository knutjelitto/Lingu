namespace Lipeg.Runtime
{
    public class MessageError : Message
    {
        public MessageError(MessageCode code, string message)
            : base(MessageSeverity.Error, code, message)
        {
        }
        public MessageError(MessageCode code, ILocated located)
            : base(MessageSeverity.Error, code, located)
        {
        }
    }
}
