using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;
using Lingu.Writers;

namespace Lingu.Dumping
{
    public class TableDumper
    {
        const int shortLength = 6;
        public TableDumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Dump(IWriter writer)
        {
            DumpSymbols(writer);
            writer.WriteLine();
            DumpProductions(writer);
            writer.WriteLine();
            DumpTable(writer);
        }

        public void DumpTable(IWriter writer)
        {
            const string topLeft = "┌";
            const string topRight = "┐";
            const string topMid = "┬";
            const string topMid2 = "╥";

            const string midLeft = "├";
            const string midRight = "┤";
            const string midMid = "┼";
            const string midMid2 = "╫";

            const string botLeft = "└";
            const string botRight = "┘";
            const string botMid = "┴";
            const string botMid2 = "╨";

            const string hBar = "─";
            const string vbar = "│";
            const string vbar2 = "║";

            var tCount = Grammar.PSymbols.Where(s => s is Terminal).Count();
            var nCount = Grammar.PSymbols.Where(s => s is Nonterminal).Count();

            var line = new string(hBar[0], shortLength);

            var tLine = Short(string.Empty) +
                        topLeft +
                        string.Join(topMid, Enumerable.Repeat(line, tCount)) +
                        topMid2 +
                        string.Join(topMid, Enumerable.Repeat(line, nCount)) +
                        topRight;
            writer.WriteLine(tLine);

            var lenght = (Grammar.PSymbols.Count) * (shortLength + 1) + 1;

            writer.Write(Short(string.Empty));

            foreach (var symbol in Grammar.PSymbols)
            {
                if (symbol.Pid == tCount)
                {
                    writer.Write(vbar2);
                }
                else
                {
                    writer.Write(vbar);
                }

                writer.Write(Short(symbol));
            }
            writer.WriteLine(vbar);

            tLine = Short(string.Empty) +
                    midLeft +
                    string.Join(midMid, Enumerable.Repeat(line, tCount)) +
                    midMid2 +
                    string.Join(midMid, Enumerable.Repeat(line, nCount)) +
                    midRight;
            writer.WriteLine(tLine);

            Debug.Assert(Grammar.Table != null);
            var table = Grammar.Table;

            for (var stateNo = 0; stateNo < Grammar.LR1Sets.Count; ++stateNo)
            {
                writer.Write(Short(stateNo.ToString()));

                for (var symNo = 0; symNo < Grammar.PSymbols.Count; ++ symNo)
                {
                    if (symNo == tCount)
                    {
                        writer.Write(vbar2);
                    }
                    else
                    {
                        writer.Write(vbar);
                    }

                    writer.Write(Short(table[stateNo, symNo].LastOrDefault()));
                }
                writer.Write(vbar);

                writer.WriteLine();
            }

            tLine = Short(string.Empty) +
                    botLeft +
                    string.Join(botMid, Enumerable.Repeat(line, tCount)) +
                    botMid2 +
                    string.Join(botMid, Enumerable.Repeat(line, nCount)) +
                    botRight;
            writer.WriteLine(tLine);
        }

        private string Short(string sym)
        {
            if (sym.Length >= shortLength)
            {
                return sym.Substring(0, shortLength);
            }
            return sym.PadRight(shortLength);
        }

        private string Short(Symbol symbol)
        {
            return Short(symbol.ToShort());
        }

        private string Short(TableAction cell)
        {
            string s = string.Empty;
            if (cell is Reduce reduce)
            {
                s = $"«{reduce.Production}»";
            }
            else if (cell is Shift shift)
            {
                s = $"s{shift.State}";
            }
            else if (cell is Accept)
            {
                s = "acc";
            }

            return Short(s);
        }

        private string Private(Symbol symbol)
        {
            return symbol.IsPrivate ? "P" : " ";
        }

        private string Pid(Symbol symbol)
        {
            return symbol.IsPid ? symbol.Pid.ToString() : string.Empty;
        }

        private void DumpSymbols(IWriter writer)
        {
            foreach (var s in Grammar.Terminals)
            {
                writer.WriteLine($"T {Private(s)} {Pid(s),4} {s.Id,4}  {Short(s)}  {s}");
            }
            writer.WriteLine();
            foreach (var s in Grammar.Nonterminals)
            {
                writer.WriteLine($"N {Private(s)} {Pid(s),4} {s.Id,4}  {Short(s)}  {s}");
            }
            writer.WriteLine();
            foreach (var s in Grammar.Symbols)
            {
                var tn = s is Terminal ? "T" : "N";
                writer.WriteLine($"{tn} {Private(s)} {Pid(s),4} {s.Id,4}  {Short(s)}  {s}");
            }
        }

        private void DumpProductions(IWriter writer)
        {
            foreach (var production in Grammar.Productions)
            {
                writer.WriteLine($"{Short($"«{production.Id}»")} {production.ToStringArrow()}" );
            }
        }
    }
}
