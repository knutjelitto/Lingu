using Lingu.Commons;
using Lingu.Dumping;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;
using System;

namespace Lingu.CC
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = LinguContext.CreateContext();

            var file = FileRef.From(@"D:\Projects\Lingu\Lingu.Bootstrap\Grammar\Lingu.Grammar");

            var source = Source.FromFile(file);

            var lexer = new Lexer(context, source);

            var parser = new Parser(context, lexer);

            var parseTree = parser.Parse();

            var dumper = new TreeDumper(FileRef.From(@"D:\Projects\Lingu\Lingu.Bootstrap\Grammar\Out\Lingu.Out.Out.Tree"));
            dumper.Dump(parseTree);

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
