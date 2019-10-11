using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Commons;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Write
{
    public class CSharpContext
    {
        public CSharpContext(Grammar grammar, string @namespace, DirRef output, CsWriter writer = null)
        {
            Grammar = grammar;
            Namespace = @namespace;
            Output = output;
            Writer = writer;
        }

        public Grammar Grammar { get; }
        public string Namespace { get; }
        public DirRef Output { get; }
        public CsWriter Writer { get; }

        public string ContextClass => $"{Grammar.Name}Context";
        public FileRef ContextClassFile => Output.File(ContextClass).Add(".cs");
        public string VisitorClass => $"{Grammar.Name}Visitor";
        public FileRef VisitorClassFile => Output.File(VisitorClass).Add(".cs");
        public string IdClass => $"{Grammar.Name}Id";
        public string DataSubClass => "Data";
        public FileRef DataSubClassFile => Output.File($"{ContextClass}.{DataSubClass}").Add(".cs");

        public CSharpContext With(CsWriter writer)
        {
            return new CSharpContext(Grammar, Namespace, Output, writer);
        }

        public CSharpContext WithWriter()
        {
            return With(new CsWriter());
        }

        public void Space()
        {
            Writer.WriteLine();
        }
    }
}
