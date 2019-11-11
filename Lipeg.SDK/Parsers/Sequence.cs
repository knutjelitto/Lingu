using System;
using System.Collections.Generic;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Sequence : IParser
    {
        public Sequence(params IParser[] parsers)
        {
            Parsers = parsers;
        }

        private IReadOnlyCollection<IParser> Parsers { get; }

        public IResult Parse(ICursor cursor)
        {
            var current = cursor;
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(current);
                if (result is IFail)
                { 
                }
            }
        }
    }
}
