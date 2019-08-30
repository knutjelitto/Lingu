using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalRepetition : TerminalExpression
    {
        public TerminalRepetition(TerminalExpression expression, int? min = null, int? max = null)
        {
            Expression = expression;
            Min = min;
            Max = max;
        }

        public TerminalExpression Expression { get; }
        public int? Min { get; }
        public int? Max { get; }

        private string Rep
        {
            get
            {
                if (Min == 0 && Max == 1)
                    return "?";
                if (Min == 0 && Max == null)
                    return "*";
                if (Min == 1 && Max == null)
                    return "+";
                Debug.Assert(Min != null && Max != null);
                if (Min == Max)
                    return $"<{Min}>";
                return $"<{Min},{Max}>";
            }
        }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.Write("| ");
            }
            Expression.Dump(output, false);
            output.Write(Rep);
            if (top)
            {
                output.WriteLine("");
            }
        }
    }
}
