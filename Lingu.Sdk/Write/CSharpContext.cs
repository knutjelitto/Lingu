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
        public string VisitorClass => $"{Grammar.Name}Visitor";
        public string DataSubClass => "Data";

        public CSharpContext With(CsWriter writer)
        {
            return new CSharpContext(Grammar, Namespace, Output, writer);
        }

        public CSharpContext WithWriter()
        {
            return new CSharpContext(Grammar, Namespace, Output, new CsWriter());
        }

        public void Space()
        {
            Writer.WriteLine();
        }
    }
}
