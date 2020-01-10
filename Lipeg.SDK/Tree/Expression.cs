using Lipeg.Runtime;
using System;
using Lipeg.SDK.Checkers;

namespace Lipeg.SDK.Tree
{
    public abstract class Expression : IExpression
    {
        protected internal Expression(ILocated located)
        {
            if (located == null) throw new ArgumentNullException(nameof(located));

            Location = located.Location;
        }

        public ILocation Location { get; }
        public IExpressionAttributes Attr { get; } = new ExpressionAttributes();
    }
}
