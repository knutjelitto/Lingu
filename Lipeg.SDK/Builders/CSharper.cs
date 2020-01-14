using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Builders
{
    public class CSharper
    {
        private readonly CsWriter writer;

        public CSharper(CsWriter writer)
        {
            this.writer = writer;
        }

        public string this[string line]
        {
            get
            {
                this.writer.WriteLine(line);
                return String.Empty;
            }
        }

        public void L()
        {
            this.writer.WriteLine();
        }

        public void L(string line)
        {
            this.writer.WriteLine(line);
        }

        public void Block(string head, Action body)
        {
            this.writer.Block(head, body);
        }

        public void Indent(string head, Action body)
        {
            this.writer.Indent(head, body);
        }

        public void If(string condition, Action thenBody, Action? elseBody = null)
        {
            writer.Block($"if ({condition})", thenBody);
            if (elseBody != null)
            {
                writer.Block($"else", elseBody);
            }
        }

        public void ForEver(Action body)
        {
            this.writer.Block("for (;;)", body);
        }
    }
}
