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
            var result = Timer.Time("parse", () => parser.Parse(current));
            if (!result.IsSuccess || !result.Next.AtEnd)
            {
                Console.WriteLine("ERROR");
                return;
            }

            var loop = 5;

            var sum = TimeSpan.Zero;
            for (var i = 0; i < loop; ++i)
            {
                result = Timer.Time("parse", ref sum, () => parser.Parse(current));
            }
            Console.WriteLine($"Ø parse: {sum / loop}");

            Dumper.Nodes(debugDir.File("nodes"), result.Nodes);

            var ast = Timer.Time("aster", () => SDK.Checkers.Builder.BuildAst(result.Nodes[0]));
            sum = TimeSpan.Zero;
            for (var i = 0; i < loop; ++i)
            {
                ast = Timer.Time("aster", ref sum, () => SDK.Checkers.Builder.BuildAst(result.Nodes[0]));
            }
            Console.WriteLine($"Ø aster: {sum / loop}");

            Dumper.Pretty(debugDir.File("ast"), ast);
        }
    }
}
