using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Writers;

namespace Lingu.Build
{
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    public class CSharpBuilder
    {
        public CSharpBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        private Grammar Grammar { get; }

        public void Build(DirRef output)
        {
            const string ns = "Grammar";

            var file = output.WithFile($"{Grammar.Name}.Data.cs");

            var writer = new CsWriter();
            writer.WriteLine("#if true");
            writer.Block($"namespace {ns}", () =>
            {
                writer.WriteLine("using Lingu.Runtime.Concretes;");
                writer.WriteLine();

                writer.Block("public static partial class Data", () =>
                {
                    writer.Block("public static ushort[] u16table = ", () =>
                    {
                        var count = 0;
                        foreach (var value in Enumerate())
                        {
                            writer.Write($"{value},");
                            count += 1;
                            if (count == 64)
                            {
                                writer.WriteLine();
                                count = 0;
                            }
                        }
                        if (count > 0)
                        {
                            writer.WriteLine();
                        }

                        IEnumerable<string> Enumerate()
                        {
                            for (var row = 0; row < Grammar.ParseTable.NumberOfStates; row += 1)
                            {
                                for (var col = 0; col < Grammar.ParseTable.NumberOfSymbols; col += 1)
                                {
                                    yield return ((ushort) Grammar.ParseTable[row, col]).ToString().PadLeft(5);
                                }
                            }
                        }
                    });
                    writer.WriteLine(";");
                });
            });
            writer.WriteLine("#endif");
            writer.Persist(file);


            file = output.WithFile($"{Grammar.Name}.Structs.cs");

            writer = new CsWriter();
            writer.WriteLine("#if true");

            writer.Block($"namespace {ns}", () =>
            {
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine();
                writer.WriteLine("using Lingu.Runtime.Concretes;");
                writer.WriteLine("using Lingu.Runtime.Parsing;");
                writer.WriteLine("using Lingu.Runtime.Structures;");
                writer.WriteLine();

                writer.Block("public static partial class Data", () =>
                {
                    var n1 = Grammar.ParseTable.NumberOfStates;
                    var n2 = Grammar.ParseTable.NumberOfTerminals;
                    var n3 = Grammar.ParseTable.NumberOfSymbols;

                    writer.WriteLine($"public static readonly ParseTable Table = new U16ParseTable(u16table, {n1}, {n2}, {n3});");
                    writer.WriteLine();

                    foreach (var symbol in Grammar.Symbols)
                    {
                        if (symbol is Terminal terminal)
                        {
                            writer.Write($"public static readonly TerminalSymbol {terminal.Name} = ");
                            writer.WriteLine($"new TerminalSymbol({terminal.Id}, \"{terminal.Name}\", \"{terminal.Visual}\");");
                        }
                        else if (symbol is Nonterminal nonterminal)
                        {
                            writer.Write($"public static readonly NonterminalSymbol {nonterminal.Name} = ");
                            writer.WriteLine($"new NonterminalSymbol({nonterminal.Id}, \"{nonterminal.Name}\", {nameof(RepeatKind)}.{nonterminal.Repeat}, {nameof(LiftKind)}.{nonterminal.Lift});");
                        }
                    }

                    writer.WriteLine();

                    writer.Block("public static readonly Symbol[] Symbols = ",
                                 () =>
                                 {
                                     WriteExtend(writer, Grammar.Symbols.Select(symbol => symbol.Name), 80);
                                 });
                    writer.WriteLine(";");

                    writer.WriteLine();

                    writer.Block("public static readonly Production[] Productions = ",
                                 () =>
                                 {
                                     foreach (var production in Grammar.Productions)
                                     {
                                         var drops = string.Join(", ", production.Drops.Select(b => b ? "true" : "false"));
                                         var sep = drops.Length > 0 ? ", " : string.Empty;
                                         writer.WriteLine($"new Production({production.Nonterminal.Name}{sep}{drops}),");
                                     }
                                 });
                    writer.WriteLine(";");

                    writer.WriteLine();
                });
            });

            writer.WriteLine("#endif");
            writer.Persist(file);
        }

        private void WriteExtend(IndentWriter writer, IEnumerable<string> values, int extend)
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
    }
}
