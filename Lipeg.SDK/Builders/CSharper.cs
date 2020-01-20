using System;
using System.Collections.Generic;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Builders
{
    public class CSharper
    {
        private readonly IndentWriter writer;
        private readonly bool withComments;
        private readonly Dictionary<string, int> locals = new Dictionary<string, int>();

        public CSharper(IndentWriter writer, bool withComments = false)
        {
            this.writer = writer;
            this.withComments = withComments;
        }

        public IEnumerable<string> Lines => writer.Lines;

        public Local Local(string stem)
        {
            if (locals.TryGetValue(stem, out var num))
            {
                num += 1;
                locals[stem] = num;
            }
            else
            {
                num = 1;
                locals.Add(stem, num);
            }
            return new Local(stem, num);
        }

        public void Ln()
        {
            this.writer.WriteLine();
        }

        public void Ln(string line)
        {
            this.writer.WriteLine(line);
        }

        public void Ln(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));

            foreach (var line in lines)
            {
                Ln(line);
            }
        }

        public void Block(string head, Action body)
        {
            this.writer.Block(head, body);
        }

        public void IndentInOut(string comment, Action body)
        {
            if (withComments)
            {
                Ln($"// {{{{{comment}");
                this.writer.Indent(body);
                Ln($"// }}}}{comment}");
            }
            else
            {
                body?.Invoke();
            }
        }

        public void IndentInOut(bool withComments, string comment, Action body)
        {
            if (withComments)
            {
                Ln($"// {{{{{comment}");
                this.writer.Indent(body);
                Ln($"// }}}}{comment}");
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

        public void ForEach(string iter, Action body)
        {
            this.writer.Block($"foreach ({iter})", body);
        }
    }
}
