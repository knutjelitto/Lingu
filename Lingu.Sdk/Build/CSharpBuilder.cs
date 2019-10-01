using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Build
{
    public class CSharpBuilder
    {
        public CSharpBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Build(DirRef output)
        {
            const string ns = "Grammar";

            var pFile = output.WithFile($"{Grammar.Name}.Data.cs");

            var pWriter = new CsWriter();
            pWriter.WriteLine("#if true");
            pWriter.Block($"namespace {ns}", () =>
            {
                pWriter.Block($"public static partial class Data", () =>
                {
                    pWriter.Indend("public const string tableString = ", () =>
                    {
                        var count = 0;
                        for (var row = 0; row < Grammar.ParseTable.NumberOfStates; row += 1)
                        {
                            for (var col = 0; col < Grammar.ParseTable.NumberOfSymbols; col += 1)
                            {
                                if (count == 0)
                                {
                                    pWriter.Write("\"");
                                }
                                pWriter.Write($"\\u{((ushort)Grammar.ParseTable[row, col]):X4}");
                                count += 1;
                                if (count == 16)
                                {
                                    pWriter.WriteLine("\" +");
                                    count = 0;
                                }
                            }
                        }
                        if (count > 0)
                        {
                            pWriter.WriteLine("\";");
                        }
                    });
                });
            });
            pWriter.WriteLine("#endif");
            pWriter.Persist(pFile);


            pFile = output.WithFile($"{Grammar.Name}.Structs.cs");

            pWriter = new CsWriter();
            pWriter.WriteLine("#if true");

            pWriter.Block($"namespace {ns}", () =>
            {
                pWriter.WriteLine($"using Lingu.Runtime.Parsing;");

                pWriter.Block($"public static partial class Data", () =>
                {
                    var n1 = Grammar.ParseTable.NumberOfStates;
                    var n2 = Grammar.ParseTable.NumberOfTerminals;
                    var n3 = Grammar.ParseTable.NumberOfSymbols;

                    pWriter.WriteLine($"public static readonly ParseTable Table = new StringParseTable(tableString, {n1}, {n2}, {n3});");
                });
            });

            pWriter.WriteLine("#endif");
            pWriter.Persist(pFile);
        }
    }
}
