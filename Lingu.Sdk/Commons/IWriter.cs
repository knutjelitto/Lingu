using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Commons
{
    public class IWriter
    {
        private readonly List<string> lines;
        private readonly string tab;
        private string prefix;
        private string current;

        public IWriter(string tab = "    ")
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

        private void AddLine(string line)
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

        public void Indend(string head, Action body)
        {
            AddLine(head);
            using (Indent())
            {
                body();
            }
        }

        private IDisposable Indent()
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
