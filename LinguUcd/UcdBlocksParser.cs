using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Lingu.CC;
using Lingu.Commons;
using Lingu.Runtime.Sources;
using Lingu.Runtime.Structures;

namespace Lingu.Ucd
{
    public class UcdBlocksParser
    {
        public void Parse(FileRef file)
        {
            var source = Source.FromFile(file);
            var context = new UcdBlocksContext();

            var parseTree = context.Try(source);

            if (parseTree != null)
            {
                var ast = new Visitor().Visit(parseTree).ToList();
            }
        }

        private class Visitor : UcdBlocksVisitor<object>
        {
            protected override object DefaultOn(IToken token) => throw new NotImplementedException();

            public IEnumerable<(int from, int to, string id)> Visit(INonterminalToken root)
            {
                foreach (var preData in ((INonterminalToken)root[0]).Children.Where(x => x.Symbol.Id == UcdBlocksId.Data).Cast<INonterminalToken>())
                {
                    if (preData.Symbol.Id == UcdBlocksId.Data)
                    {
                        var begin = int.Parse(preData.Nonterminal(0).Terminal(0).Value, NumberStyles.HexNumber);
                        var end = int.Parse(preData.Nonterminal(0).Terminal(1).Value, NumberStyles.HexNumber);
                        var id = preData.Terminal(1).Value;

                        yield return (begin, end, id);
                    }
                }
            }

        }
    }
}
