using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Grammars;

namespace Lingu.Build
{
    public class CSharpContext
    {
        public CSharpContext(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public string ContextClass => $"{Grammar.Name}Context";
        public string VisitorClass => $"{Grammar.Name}Visitor";
        public string DataSubClass => "Data";
    }
}
