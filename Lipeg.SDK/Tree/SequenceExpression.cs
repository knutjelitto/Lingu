using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(IStarList<Expression> sequence)
        {
            Sequence = sequence;
        }
        public IStarList<Expression> Sequence { get; }

        public static SequenceExpression From(IStarList<Expression> sequence)
        {
            return new SequenceExpression(sequence);
        }

    }
}
