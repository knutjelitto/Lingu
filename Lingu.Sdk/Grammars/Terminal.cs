using Lingu.Runtime.LexDfa;
using Lingu.Tree;
using Lingu.Writers;
using System.Diagnostics;

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

        public override void Dump(IndentWriter writer)
        {
            var p = IsPrivate ? "private " : "";
            var a = IsGenerated ? $"{Visual} " : "";
            writer.Indend($"{Name} // {p}{a}({Id})", () =>
            {
                if (Raw.Expression is Alternates alternates)
                {
                    bool more = false;
                    foreach (var alt in alternates.Expressions)
                    {
                        if (more)
                        {
                            writer.Write("| ");
                        }
                        else
                        {
                            writer.Write(": ");
                        }
                        more = true;

                        alt.Dump(writer);
                        writer.WriteLine();
                    }
                }
                else
                {
                    writer.Write(": ");
                    Raw.Expression.Dump(writer);
                    writer.WriteLine();
                }
                writer.WriteLine(";");
            });
        }
    }
}
