namespace Lipeg.Runtime
{
    public class MessageFatal : Message
    {
        public MessageFatal(MessageCode code, string message)
            : base(MessageSeverity.Fatal, code, message)
        {
        }
    }
}
