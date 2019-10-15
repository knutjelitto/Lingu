using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Build;
using Lingu.Grammars;
using Lingu.LR;
using Lingu.Output;

namespace Lingu.Dumping
{
    public class TableDumper
    {
        const int shortLength = 10;
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
            DumpTable(writer, new RawTabler(this));
        }

        private static void DumpTable(IWriter writer, Tabler tabler)
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

            var stateCount = tabler.NumberOfStates;
            var terminalCount = tabler.NumberOfTerminals;
            var nonterminalCount = tabler.NumberOfNonterminals;
            var symbolCount = tabler.NumberOfSymbols;

            var line = new string(hBar[0], shortLength);

            var tLine = Short(string.Empty) +
                        topLeft +
                        string.Join(topMid, Enumerable.Repeat(line, terminalCount)) +
                        topMid2 +
                        string.Join(topMid, Enumerable.Repeat(line, nonterminalCount)) +
                        topRight;
            writer.WriteLine(tLine);

            writer.Write(Short(string.Empty));

            foreach (var symbol in tabler.Grammar.PSymbols)
            {
                if (symbol.Pid == terminalCount)
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
                    string.Join(midMid, Enumerable.Repeat(line, terminalCount)) +
                    midMid2 +
                    string.Join(midMid, Enumerable.Repeat(line, nonterminalCount)) +
                    midRight;
            writer.WriteLine(tLine);

            for (var stateNo = 0; stateNo < stateCount; ++stateNo)
            {
                writer.Write(Short(stateNo.ToString()));

                for (var symNo = 0; symNo < symbolCount; ++symNo)
                {
                    if (symNo == terminalCount)
                    {
                        writer.Write(vbar2);
                    }
                    else
                    {
                        writer.Write(vbar);
                    }

                    writer.Write(tabler.Display(stateNo, symNo));
                }
                writer.Write(vbar);

                writer.WriteLine();
            }

            tLine = Short(string.Empty) +
                    botLeft +
                    string.Join(botMid, Enumerable.Repeat(line, terminalCount)) +
                    botMid2 +
                    string.Join(botMid, Enumerable.Repeat(line, nonterminalCount)) +
                    botRight;
            writer.WriteLine(tLine);
        }

        private abstract class Tabler
        {
            public Tabler(TableDumper dumper)
            {
                Dumper = dumper;
            }
            public TableDumper Dumper { get; }
            public Grammar Grammar => Dumper.Grammar;

            public abstract int NumberOfStates { get; }
            public abstract int NumberOfTerminals { get; }
            public abstract int NumberOfNonterminals { get; }
            public int NumberOfSymbols => NumberOfTerminals + NumberOfNonterminals;
            public abstract string Display(int stateNo, int symNo);
        }

        private class RawTabler : Tabler
        {
            public RawTabler(TableDumper dumper)
                : base(dumper)
            {
                NumberOfStates = dumper.Grammar.LR1Sets.Count;
                NumberOfTerminals = dumper.Grammar.PSymbols.Where(s => s is Terminal).Count();
                NumberOfNonterminals = dumper.Grammar.PSymbols.Where(s => s is Nonterminal).Count();
            }

            public override int NumberOfStates { get; }
            public override int NumberOfTerminals { get; }
            public override int NumberOfNonterminals { get; }
            public override string Display(int stateNo, int symNo)
            {
                return Short(Grammar.Table[stateNo, symNo]);
            }
        }

        private static string Short(string sym)
        {
            if (sym.Length >= shortLength)
            {
                return sym.Substring(0, shortLength);
            }
            return sym.PadRight(shortLength);
        }

        private static string Short(Symbol symbol)
        {
            return Short(symbol.ToShort());
        }

        private static string Short(TableCell actions)
        {
            string s = string.Empty;

            foreach (var action in actions.Distinct())
            {
                if (action is Reduce reduce)
                {
                    s = $"{s}«{reduce.Production}»";
                }
                else if (action is Shift shift)
                {
                    s = $"{s}s{shift.State}";
                }
                else if (action is Accept)
                {
                    s = $"{s}acc";
                }
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
