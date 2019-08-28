using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Hime.Redist;

namespace Mean.Language
{
    internal class DumpVisitor : Generated.MeanVisitor
    {
        private int level = 0;

        private void Dump(ASTNode node)
        {
            Console.WriteLine($"{new string(' ', level * 4)} {node}");
        }

        public void Visit(ParseResult result)
        {
            VisitNode(result.Root);
        }
    }
}
