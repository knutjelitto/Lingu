using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;
using Lingu.Writers;

#nullable enable

namespace Lingu.Build
{
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    public class CSharpWriter : CSharpWriterTools
    {
        public CSharpWriter(Grammar grammar)
            : base(grammar)
        {
        }

        public void Build(DirRef output)
        {
            const string @namespace = "Lingu.CC";

            var terminalType = nameof(TerminalSymbol);
            var nonterminalType = nameof(NonterminalSymbol);

            var contextClass = $"{Grammar.Name}Context";
            var dataClass = $"Data";

            var file = output.WithFile($"{contextClass}.{dataClass}.cs");

            var writer = new CsWriter();
            writer.Block($"namespace {@namespace}", () =>
            {
                writer.Using("System.Linq");
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Lexing");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block($"public partial class {contextClass}", () =>
                {
                    writer.Block($"public static class {dataClass}", () =>
                    {
                        new CSharpWriterDfaSet(Grammar, writer).Write();

                        writer.WriteLine();

                        new CSharpWriterParseTable(Grammar, writer).Write();
                    });
                });
            });
            writer.Persist(file);

            file = output.WithFile($"{Grammar.Name}Context.cs");

            writer = new CsWriter();

            writer.Block($"namespace {@namespace}", () =>
            {
                writer.Using("Lingu.Runtime.Concretes");
                writer.Using("Lingu.Runtime.Lexing");
                writer.Using("Lingu.Runtime.Parsing");
                writer.Using("Lingu.Runtime.Structures");
                writer.WriteLine();

                writer.Block($"public partial class {contextClass}", () =>
                {
                    Debug.Assert(Grammar.Symbols != null);
                    foreach (var symbol in Grammar.Symbols)
                    {
                        if (symbol is Terminal terminal)
                        {
                            writer.Write($"public static readonly {terminalType} {terminal.Name} = ");
                            writer.WriteLine($"new {terminalType}({terminal.Id}, \"{terminal.Name}\", {Bool(terminal.IsVisible)}, \"{terminal.Visual}\");");
                        }
                        else if (symbol is Nonterminal nonterminal)
                        {
                            writer.Write($"public static readonly {nonterminalType} {nonterminal.Name} = ");
                            writer.WriteLine($"new {nonterminalType}({nonterminal.Id}, \"{nonterminal.Name}\", {Bool(nonterminal.IsPrivate)}, {nameof(RepeatKind)}.{nonterminal.Repeat}, {nameof(LiftKind)}.{nonterminal.Lift});");
                        }
                    }

                    writer.WriteLine();

                    writer.Data("public static readonly Symbol[] Symbols = ",
                    () =>
                    {
                        WriteExtend(writer, Grammar.Symbols.Select(symbol => symbol.Name));
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
    }
}
