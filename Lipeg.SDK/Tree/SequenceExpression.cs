using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(ILocated located, IStarList<Expression> sequence)
            : base(located)
        {
            Sequence = sequence;
        }
        public IStarList<Expression> Sequence { get; }

        public static SequenceExpression From(ILocated located, IStarList<Expression> sequence)
        {
            return new SequenceExpression(located, sequence);
        }

    }
}
