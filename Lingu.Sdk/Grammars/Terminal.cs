using Lingu.Runtime.LexDfa;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Terminal : Rule
    {
        public Terminal(string name)
            : base(name)
        {
        }

        public Dfa Dfa { get; set; }
        public byte[] Bytes { get; set; }
        public string Visual { get; set; }
        public RawTerminal Raw { get; set; }

        public override void Dump(IndentWriter output, bool top)
        {
            var p = IsPrivate ? "private " : "";
            var a = IsGenerated ? $"{Visual} " : "";
            output.Indend($"{Name} // {p}{a}({Id})", () =>
            {
                if (Raw.Expression is Alternates)
                {
                    Raw.Expression.Dump(output, true);
                }
                else
                {
                    output.Write(": ");
                    Raw.Expression.Dump(output, true);
                    output.WriteLine();
                }
                output.WriteLine(";");
            });
        }
    }
}
