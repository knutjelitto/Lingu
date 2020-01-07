using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(ILocated located, IList<Expression> sequence)
            : base(located)
        {
            Sequence = sequence;
        }
        public IList<Expression> Sequence { get; }

        public static SequenceExpression From(ILocated located, IEnumerable<Expression> sequence)
        {
            return new SequenceExpression(located, sequence.ToList());
        }

    }
}
