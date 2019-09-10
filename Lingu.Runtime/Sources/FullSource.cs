using System;
using System.Collections.Generic;

namespace Lingu.Runtime.Sources
{
    public class FullSource : BaseSource
    {
        public FullSource(string name, string content)
            : base(name)
        {
            Content = content;
        }

        public string Content { get; }

        public override int Length => Content.Length;

        public override ReadOnlySpan<char> GetLineContent(int lineNo)
        {
            throw new NotImplementedException();
        }

        public override int GetLineIndex(int lineNo)
        {
            throw new NotImplementedException();
        }

        public override ReadOnlySpan<char> GetSpan(int start, int length)
        {
            return Content.AsSpan(start, length);
        }

        public override string GetText(int start, int length)
        {
            return new string(Content.AsSpan(start, length));
        }

        /// <summary>
        /// Finds all the lines in this content
        /// </summary>
        protected override List<int> FindLines()
        {
            var lines = new List<int>(10000);
            lines.Add(0);
            char c1;
            char c2 = '\0';
            for (int i = 0; i != Content.Length; i++)
            {
                c1 = c2;
                c2 = Content[i];
                // is c1 c2 a line ending sequence?
                if (IsLineEnding(c1, c2))
                {
                    // are we late to detect MacOS style?
                    if (c1 == '\u000D' && c2 != '\u000A')
                        AddLine(i);
                    else
                        AddLine(i + 1);
                }
            }

            return lines;
        }

    }
}
