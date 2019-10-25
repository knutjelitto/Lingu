using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(IReadOnlyList<Expression> sequence)
        {
            Sequence = sequence;
        }
        public IReadOnlyList<Expression> Sequence { get; }

        public static SequenceExpression From(IReadOnlyList<Expression> sequence)
        {
            return new SequenceExpression(sequence);
        }

    }
}
