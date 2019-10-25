using System;

namespace Lipeg.Boot
{
    public interface ILexer
    {
        public bool AtEnd();

        public bool Skip(Func<char, bool> predicate);

        public bool Match(string chars);

        public string Match();

        public bool Match(Func<char, bool> predicate);
    }
}
