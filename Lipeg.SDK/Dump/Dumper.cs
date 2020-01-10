using System;
using System.Collections.Generic;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Dump
{
    public static class Dumper
    {
        public static void Dump<T>(Grammar grammar, FileRef file, IDump<T> dump, T subject)
        {
            if (dump == null) throw new ArgumentNullException(nameof(dump));

            var writer = new IndentWriter();
            dump.Dump(grammar, writer, subject);
            writer.Persist(file);
        }

        private static void Dump(FileRef file, Action<IWriter> dump)
        {
            var writer = new IndentWriter();
            dump(writer);
            writer.Persist(file);
        }

        public static void Nodes(FileRef file, IEnumerable<INode> nodes)
        {
            Dump(file, writer => new DumpNodes().Dump(writer, nodes));
        }

        public static void Pretty(FileRef file, Grammar grammar)
        {
            Dump(file, writer => new DumpPpGrammar().Dump(grammar, writer, false));
        }

        public static void Parsers(FileRef file, Grammar grammar)
        {
            Dump(file, writer => new DumpParsers().Dump(grammar, writer, false));
        }


    }
}
