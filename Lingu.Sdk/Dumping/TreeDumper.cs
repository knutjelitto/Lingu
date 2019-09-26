using Lingu.Runtime.Structures;
using Lingu.Writers;
using Mean.Maker.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lingu.Dumping
{
    public class TreeDumper
    {
        public TreeDumper(FileRef file)
        {
            File = file;
        }

        public INonterminalToken Token { get; }
        public FileRef File { get; }

        public void Dump(INonterminalToken token)
        {
            var iwriter = new IndentWriter("  ");
            Dump(iwriter, token);
            iwriter.Persist(File);
        }

        private void Dump(IWriter writer, IToken token)
        {
            writer.WriteLine($"{token.Symbol.Name}");
            writer.Indend(() =>
            {
                if (token is INonleafToken nonleaf)
                {
                    foreach (var child in nonleaf.Children)
                    {
                        Dump(writer, child);
                    }
                }
            });
        }
    }
}
