using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class SequenceExpression : Expression
    {
        private SequenceExpression(IEnumerable<Expression> sequence)
        {
            Sequence = sequence.ToList().AsReadOnly();
        }
        public IReadOnlyList<Expression> Sequence { get; }

        public static SequenceExpression From(IEnumerable<Expression> sequence)
        {
            return new SequenceExpression(sequence);
        }

    }
}
