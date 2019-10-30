using System;

using Lipeg.SDK.Common;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;
using Lipeg.SDK.Checking;

namespace Lipeg.Boot
{
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine("Hello World!");

            Build("lipeg.lpg");
            
            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private static void Build(string grammarFile)
        {
            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var debugOut = projectDir.Dir("DebugOut");

            var lpgGrammar = grammarDir.File(grammarFile);


            Environment.CurrentDirectory = debugOut;

            var result = new CompileResult();

            var source = Source.FromFile(result, lpgGrammar);

            if (!result.ShouldStop && source != null)
            {

                var parser = new LipegParser(source);

                GC.TryStartNoGCRegion(32 * 1024 * 1024);
                var parseTree = Timer.TimeBoth("parse", () => parser.Parse(source.ToString(), lpgGrammar));
                GC.EndNoGCRegion();

                var parseTreeFile = debugOut.File(lpgGrammar.FileName).Add(".tree");
                Dumper.Dump(parseTreeFile, new DumpParseTree(), parseTree);

                var grammarBuilder = new GrammarBuilder();

                GC.TryStartNoGCRegion(32 * 1024 * 1024);
                var grammar = Timer.TimeBoth("build tree", () => grammarBuilder.Build(parseTree));
                GC.EndNoGCRegion();
            }

            if (result.HasErrors)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"{error.Code}: {error.Message}");
                }
            }

        }
    }
}
