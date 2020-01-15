using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Builders
{
    public class CSharper
    {
        private readonly CsWriter writer;
        private readonly bool withComments;

        public CSharper(CsWriter writer, bool withComments = false)
        {
            this.writer = writer;
            this.withComments = withComments;
        }

        public void Line()
        {
            this.writer.WriteLine();
        }

        public void Line(string line)
        {
            this.writer.WriteLine(line);
        }

        public void Block(string head, Action body)
        {
            this.writer.Block(head, body);
        }

        public void IndentInOut(string comment, Action body)
        {
            if (withComments)
            {
                Line($"// {{{{{comment}");
                this.writer.Indent(body);
                Line($"// }}}}{comment}");
            }
            else
            {
                body?.Invoke();
            }
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
