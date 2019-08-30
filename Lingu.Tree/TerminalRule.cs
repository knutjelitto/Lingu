using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalRule : TerminalExpression
    {
        public TerminalRule(AtomName name, TerminalExpression definition)
        {
            Name = name;
            Definition = definition;
        }

        public AtomName Name { get; }
        public TerminalExpression Definition { get; }

        public override void Dump(Indentable output, bool top)
        {
            output.Indend($"{Name}", () =>
            {
                Definition.Dump(output, top);
                output.WriteLine(";");
            });
        }
    }
}
