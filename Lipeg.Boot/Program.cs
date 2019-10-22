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

            var source = Source.FromFile(lipegGrammar);
            var lexer = Lexer.From(source);
            var parser = Parser.From(lexer);

            parser.Parse();

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
