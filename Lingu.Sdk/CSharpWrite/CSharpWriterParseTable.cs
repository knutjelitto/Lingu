using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Output;

#nullable enable

namespace Lingu.CSharpWrite
{
    public class CSharpWriterParseTable : CSharpWriterTools
    {
        private readonly CsWriter writer;

        public CSharpWriterParseTable(CSharpContext ctx)
            : base(ctx)
        {
            this.writer = ctx.Writer;
        }

        public void Write()
        {
            writer.Block($"public static {Ctx.ParseTableType} CreateParseTable()", () =>
            {
                Debug.Assert(Grammar.ParseTable != null);

                writer.WriteLine();
                writer.Data("ushort[] u16Table = ", () =>
                {
                    WriteExtend(writer, EnumAll(Grammar.ParseTable as IParseTable));

                    IEnumerable<string> EnumAll(IParseTable table)
                    {
                        for (var stateNo = 0; stateNo < table.NumberOfStates; ++stateNo)
                        {
                            for (var symNo = 0; symNo < table.NumberOfSymbols; ++symNo)
                            {
                                yield return table[stateNo, symNo].ToString() ?? string.Empty;
                            }
                        }
                    }
                });

                writer.WriteLine();

                var rows = Grammar.ParseTable.NumberOfStates;
                var nt = Grammar.ParseTable.NumberOfTerminals;
                var cols = Grammar.ParseTable.NumberOfSymbols;

                writer.WriteLine($"return U16ParseTable.From(u16Table, {rows}, {nt}, {cols});");
            });
        }
    }
}
