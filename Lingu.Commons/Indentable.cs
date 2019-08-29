using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Commons
{
    public class Indentable
    {
        private readonly List<string> lines;
        private readonly string tab;
        private string prefix;

        public Indentable(string tab = "    ")
        {
            lines = new List<string>();
            this.tab = tab;
            prefix = string.Empty;
        }

        public void Add(string line)
        {
            lines.Add($"{prefix}{line}");
        }

        public void Add2(string line)
        {
            lines.Add($"{prefix}{tab}{line}");
        }

        public void Block(string head, Action body)
        {
            Add(head);
            using (Indent())
            {
                body();
            }
            lines.Add(string.Empty);
        }

        private IDisposable Indent()
        {
            return Indent(@"{", "}");
        }

        private IDisposable Indent(string prefix, string suffix)
        {
            var prevPrefix = this.prefix;
            lines.Add($"{this.prefix}{prefix}");
            this.prefix = this.prefix + tab;
            return new Disposable(() =>
            {
                this.prefix = prevPrefix;
                lines.Add($"{this.prefix}{suffix}");
            });
        }

        public void Persist(string path)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
