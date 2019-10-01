using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Lingu.Automata;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;
using Lingu.Writers;

namespace Lingu.Build
{
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    public class CSharpBuilder
    {
        private const string terminalType = nameof(TerminalSymbol);
        private const string nonterminalType = nameof(NonterminalSymbol);

        public CSharpBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        private Grammar Grammar { get; }

        public void Build(DirRef output)
        {
            const string @namespace = "Grammar";

            var file = output.WithFile($"{Grammar.Name}.Data.cs");

            var writer = new CsWriter();
            writer.Block($"namespace {@namespace}", () =>
            {
                writer.WriteLine("using Lingu.Runtime.Concretes;");
                writer.WriteLine();

                writer.Block("public static partial class Data", () =>
                {
                    writer.Data("public static ushort[] u16Table = ", () =>
                    {
                        WriteMany(writer, 32, Grammar.ParseTable.Select(entry => ((ushort)entry).ToString().PadLeft(5)));
                    });

#if false
                    writer.Data("public static byte[] whitespace = ", () =>
                    {
                        var dfaWriter = DfaWriter.GetBytes(Grammar.WhitespaceDfa);
                    });
#endif
                });
            });
            writer.Persist(file);


            file = output.WithFile($"{Grammar.Name}.Structs.cs");

            writer = new CsWriter();

            writer.Block($"namespace {@namespace}", () =>
            {
                //writer.Using("System.Collections.Generic");
                //writer.WriteLine();
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block("public static partial class Data", () =>
                {
                    var n1 = Grammar.ParseTable.NumberOfStates;
                    var n2 = Grammar.ParseTable.NumberOfTerminals;
                    var n3 = Grammar.ParseTable.NumberOfSymbols;

                    writer.WriteLine($"public static readonly ParseTable Table = new U16ParseTable(u16Table, {n1}, {n2}, {n3});");
                    writer.WriteLine();

                    foreach (var symbol in Grammar.Symbols)
                    {
                        if (symbol is Terminal terminal)
                        {
                            writer.Write($"public static readonly {terminalType} {terminal.Name} = ");
                            writer.WriteLine($"new {terminalType}({terminal.Id}, \"{terminal.Name}\", \"{terminal.Visual}\");");
                        }
                        else if (symbol is Nonterminal nonterminal)
                        {
                            writer.Write($"public static readonly {nonterminalType} {nonterminal.Name} = ");
                            writer.WriteLine($"new {nonterminalType}({nonterminal.Id}, \"{nonterminal.Name}\", {nameof(RepeatKind)}.{nonterminal.Repeat}, {nameof(LiftKind)}.{nonterminal.Lift});");
                        }
                    }

                    writer.WriteLine();

                    writer.Data("public static readonly Symbol[] Symbols = ",
                    () =>
                    {
                        WriteExtend(writer, 80, Grammar.Symbols.Select(symbol => symbol.Name));
                    });

                    writer.WriteLine();

                    writer.Data("public static readonly Production[] Productions = ",
                    () =>
                    {
                        foreach (var production in Grammar.Productions)
                        {
                            var drops = string.Join(", ", production.Drops.Select(b => b ? "true" : "false"));
                            var visual = production.ToString();
                            var sep = drops.Length > 0 ? ", " : string.Empty;
                            writer.WriteLine($"new Production({production.Nonterminal.Name},\"{visual}\"{sep}{drops}),");
                        }
                    });
                });
            });

            writer.Persist(file);
        }

        private void WriteExtend(IndentWriter writer, int extend, IEnumerable<string> values)
        {
            foreach (var value in values)
            {
                if (writer.Extend() > 0)
                {
                    writer.Write(" ");
                }
                writer.Write($"{value},");
                if (writer.Extend() >= extend)
                {
                    writer.WriteLine();
                }
            }
            if (writer.Extend() > 0 && writer.Extend() < extend)
            {
                writer.WriteLine();
            }
        }

        private void WriteMany(IndentWriter writer, int perLine, IEnumerable<string> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                writer.Write($"{value},");
                count += 1;
                if (count == perLine)
                {
                    writer.WriteLine();
                    count = 0;
                }
            }
            if (count > 0)
            {
                writer.WriteLine();
            }
        }
    }
}
