using System;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Dump;

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
            var current = source.Start();

            var parser = new LipegParser();
            var result = Timer.Time("parse", () => parser.Start(current));
            if (!result.IsSuccess || !result.Next.AtEnd)
            {
                Console.WriteLine("ERROR");
                return;
            }
            for (var i = 0; i < 10; ++i)
            {
                result = Timer.Time("parse", () => parser.Start(current));
            }

            Dumper.Nodes(debugDir.File("nodes"), result.Nodes);


        }
    }
}
