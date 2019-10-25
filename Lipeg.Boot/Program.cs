using System;

using Lipeg.SDK.Tools;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;

namespace Lipeg.Boot
{
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine("Hello World!");

            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var lpgGrammar = grammarDir.File("lipeg.lpg");

            var source = Source.FromFile(lpgGrammar);

            var parser = new LipegParser(source);

            var parse = Timer.Time("parse", () => parser.Parse(source.ToString(), lpgGrammar));

            var treeBuilder = new TreeBuilder();

            var grammar = treeBuilder.Build(parse);
            
            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
