using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Sources
{
    public abstract class BaseSource : ISource
    {
        private readonly Lazy<List<int>> lazyLines;

        protected BaseSource(string name)
        {
            Name = name;
            lazyLines = new Lazy<List<int>>(() =>
            {
                return FindLines();
            });
        }

        protected List<int> Lines => lazyLines.Value;

        public string Name { get; }
        public abstract int Length { get; }

        /// <summary>
        /// Determines whether [c1, c2] form a line ending sequence
        /// </summary>
        /// <param name="c1">First character</param>
        /// <param name="c2">Second character</param>
        /// <returns><c>true</c> if this is a line ending sequence</returns>
        /// <remarks>
        /// Recognized sequences are:
        /// [U+000D, U+000A] (this is Windows-style \r \n)
        /// [U+????, U+000A] (this is unix style \n)
        /// [U+000D, U+????] (this is MacOS style \r, without \n after)
        /// Others:
        /// [?, U+000B], [?, U+000C], [?, U+0085], [?, U+2028], [?, U+2029]
        /// </remarks>
        protected bool IsLineEnding(char c1, char c2)
        {
            // other characters
            if (c2 == '\u000B' || c2 == '\u000C' || c2 == '\u0085' || c2 == '\u2028' || c2 == '\u2029')
                return true;
            // matches [\r, \n] [\r, ??] and  [??, \n]
            if (c1 == '\u000D' || c2 == '\u000A')
                return true;
            return false;
        }

        protected abstract List<int> FindLines();
        public abstract string GetText(int index, int length);
        public abstract ReadOnlySpan<char> GetSpan(int index, int lenght);
        public abstract int GetLineIndex(int lineNo);
        public abstract ReadOnlySpan<char> GetLineContent(int lineNo);

        /// <summary>
		/// Adds a line starting at the specified index
		/// </summary>
		/// <param name="index">An index in the content</param>
		protected void AddLine(int index)
        {
            if (Lines.Count >= Lines.Capacity)
            {
                Lines.Capacity = (Lines.Capacity * 3) / 2;
            }

            Lines.Add(index);
        }
    }
}
