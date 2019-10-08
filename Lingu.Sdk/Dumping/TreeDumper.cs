using Lingu.Commons;
using Lingu.Runtime.Structures;
using Lingu.Writers;

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
            writer.Write($"{token.Symbol.Name}");
            if (token is INonterminalToken nonleaf)
            {
                writer.WriteLine();
                writer.Indent(() =>
                {
                    foreach (var child in nonleaf.Children)
                    {
                        Dump(writer, child);
                    }
                });
            }
            else
            {
                var terminalToken = (ITerminalToken)token;

                writer.WriteLine($" <{terminalToken.Value}>");
            }
        }
    }
}
