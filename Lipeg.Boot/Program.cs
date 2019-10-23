using Lingu.Commons;
using Lipeg.Runtime;
using System;

namespace Lipeg.Boot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("Grammars");
            var lipegGrammar = grammarDir.File("lipeg.lpg");

            var parser = new LipegParser();

            var source = Source.FromFile(lipegGrammar);

            var grammar = parser.Parse(source.ToString(), lipegGrammar);

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
