using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(ILocated located, IPlusList<Expression> sequence)
            : base(located)
        {
            Sequence = sequence;
        }
        public IPlusList<Expression> Sequence { get; }

        public static SequenceExpression From(ILocated located, IPlusList<Expression> sequence)
        {
            return new SequenceExpression(located, sequence);
        }

    }
}
