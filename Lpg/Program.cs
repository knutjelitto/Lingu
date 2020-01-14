using System;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;

namespace Lipeg.Command
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Demo();

            Console.Write("(almost) any key ... ");
            Console.ReadKey(true);
        }

        private static void Demo()
        {
            var projectDir = DirRef.ProjectDir();
            var grammarDir = projectDir.Dir("..").Dir("Lipeg.Boot").Dir("Grammars");
            var debugDir = projectDir.Dir("Out");
            Environment.CurrentDirectory = debugDir;

            var grammarFile = grammarDir.File("lipeg.lpg");

            var sourceContent = grammarFile.GetContent();

            var source = Source.FromString("demo", sourceContent);
            var current = source.Start();

            var parser = new LipegParser();
            var nodes = parser.Start(current);

        }
    }
}
