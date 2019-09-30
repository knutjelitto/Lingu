using System.Diagnostics;

namespace Lingu.Runtime.Lexing
{
    [DebuggerDisplay("{DD()}")]
    public struct DfaTrans
    {
        public readonly DfaState Target;
        public readonly Set Set;

        public DfaTrans(DfaState target, Set set)
        {
            Target = target;
            Set = set;
        }

        public string DD()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"{Set}->{Target.Id}";
        }
    }
}
