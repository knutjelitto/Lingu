using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public class SubRule : Node, IExpression
    {
        public SubRule(Name name, IExpression expression)
        {
            Name = name;
            Expression = expression;
        }

        public Name Name { get; }
        public IExpression Expression { get; }
        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public override void Dump(IndentWriter writer)
        {
            writer.Write($"{{{Name}: ");
            Expression.Dump(writer);
            writer.Write($"}}");
        }

        public FA GetFA()
        {
            throw new NotImplementedException();
        }

        protected bool Equals(SubRule other)
        {
            return Equals(Name, other.Name) && Equals(Expression, other.Expression);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((SubRule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Expression != null ? Expression.GetHashCode() : 0);
            }
        }
    }
}
