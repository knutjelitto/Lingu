using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Build
{
    public class CSharpBuilder
    {
        public CSharpBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Build(DirRef output)
        {
            var pFile = output.WithFile($"{Grammar.Name}.Parser.cs");

            var pWriter = new CsWriter();
            pWriter.WriteLine("#if false");
            pWriter.WriteLine("namespace");
            pWriter.WriteLine("#endif");
            pWriter.Persist(pFile);
        }
    }
}
