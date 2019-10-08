﻿using System;
using System.Diagnostics;

using Lingu.Commons;
using Lingu.Dumping;
using Lingu.Runtime.Lexing;
using Lingu.Runtime.Parsing;
using Lingu.Runtime.Sources;

namespace Lingu.CC
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = Timer.Time("context", () => LinguContext.CreateContext());

            var file = FileRef.From(@"D:\Knut\Projects\Lingu\Lingu.Bootstrap\Grammar\Lingu.Grammar");

            var source = Timer.Time("source", () => Source.FromFile(file));

            var lexer = Timer.Time("lexer", () => new Lexer(context, source));

            var parser = Timer.Time("parser", () => new Parser(context, lexer));

            var parseTree = Timer.Time("parse", () => parser.Parse());

            var dumper = new TreeDumper(FileRef.From(@"D:\Knut\Projects\Lingu\Lingu.Bootstrap\Grammar\Out\Lingu.Out.Out.Tree"));
            dumper.Dump(parseTree);

            //var treeBuilder = new TreeBuilder();
            //var tree = treeBuilder.Visit(parseTree);

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
