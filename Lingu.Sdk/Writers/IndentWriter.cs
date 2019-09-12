using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Writers
{
    public class IndentWriter
    {
        private readonly List<string> lines;
        private readonly string tab;
        private string prefix;
        private string current;

        public IndentWriter(string tab = "    ")
        {
            lines = new List<string>();
            this.tab = tab;
            prefix = string.Empty;
            current = null;
        }

        public void WriteLine(string line)
        {
            AddLine(line);
        }

        public void WriteLine()
        {
            AddLine(string.Empty);
        }

        public void Write(string line)
        {
            Add(line);
        }

        public void Block(string head, Action body)
        {
            AddLine(head);
            AddLine("{");
            using (Indent())
            {
                body();
            }
            AddLine("}");
        }

        protected void AddLine(string line)
        {
            Begin();
            lines.Add(current + line);
            current = null;
        }

        private void Add(string line)
        {
            Begin();
            current = current + line;
        }

        private void Begin()
        {
            if (current == null)
            {
                current = prefix;
            }
        }

        public void Indend(string head, Action body)
        {
            AddLine(head);
            using (Indent())
            {
                body();
            }
        }

        public void Indend(Action body)
        {
            using (Indent())
            {
                body();
            }
        }

        protected IDisposable Indent()
        {
            var prevPrefix = prefix;
            prefix = prefix + tab;
            return new Disposable(() =>
            {
                prefix = prevPrefix;
            });
        }

        public void Persist(string path)
        {
            File.WriteAllLines(path, lines);
        }

        public void Dump(TextWriter writer)
        {
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }
}
