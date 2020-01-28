using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using System;

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
            var debugDir = projectDir.Dir("out");
            Environment.CurrentDirectory = debugDir;

            var grammarFile = projectDir.Dir("..").Dir("Lipeg.Boot").Dir("Grammars").File("lipeg.lpg");

            var sourceContent = grammarFile.GetContent();

            var source = Source.FromString("demo", sourceContent);
        }
    }
}
