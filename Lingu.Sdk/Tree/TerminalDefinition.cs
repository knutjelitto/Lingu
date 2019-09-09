using Lingu.Automata;

namespace Lingu.Tree
{
    public sealed class TerminalDefinition : Definition
    {
        public TerminalDefinition(bool generated, Name name, Expression expression)
            : base(generated, name, expression)
        {
        }

        public TerminalDefinition(Name name, Expression expression)
            : base(false, name, expression)
        {
        }

        public bool IsFragment { get; set; }

        public FA Dfa { get; set; }
        public byte[] Bytes { get; set; }
    }
}
