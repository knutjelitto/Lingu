using Lingu.Automata;
using Lingu.GrammarsOld;
using Lingu.GrammarsOld.Build;

namespace Lingu.Samples.Json
{
    //
    // https://www.json.org/
    // http://www.ecma-international.org/publications/files/ECMA-ST/ECMA-404.pdf
    // https://tools.ietf.org/html/rfc8259
    //
    // ReSharper disable once UnusedMember.Global
    public class JsonGrammar
    {
        public static Grammar Create()
        {
            RuleExpr Json = "Json";
            RuleExpr Object = "Object";
            RuleExpr Pair = "Pair";
            RuleExpr PairRepeat = "PairRepeat";
            RuleExpr Array = "Array";
            RuleExpr Value = "Value";
            RuleExpr ValueRepeat = "ValueRepeat";

            var number = NumberTerminal();
            var @string = StringTerminal();

            Json.Body = Value;

            Value.Body = @string | number | Object | Array | "false" | "true" | "null";

            Object.Body = '{' + PairRepeat + '}';

            PairRepeat.Body = Pair | (Pair + ',' + PairRepeat) | ChainExpr.Epsilon;

            Pair.Body = @string + ':' + Value;

            Array.Body = '[' + ValueRepeat + ']';

            ValueRepeat.Body = Value | (Value + ',' + ValueRepeat) | ChainExpr.Epsilon;

            return new GrammarBuilder().From(Json);
        }

        private static TerminalExpr NumberTerminal()
        {
            // [-+]?[0-9]*[.]?[0-9]+

            var digit = FA.From('0', '9');
            var sign = FA.Or(FA.From('+'), FA.From('-'));
            var dot = FA.From('.');

            var number = FA.And(sign.Opt(), digit.Star(), dot.Opt(), digit.Plus());

            return TerminalExpr.From(DfaProvision.From("number", number));
        }

        private static TerminalExpr StringTerminal()
        {
            // ["][^"]*["]

            var quotation = FA.From('"');
            var notQuotation = FA.From (((Codepoints) '"').Not());

            var @string = FA.And(quotation, notQuotation.Star(), quotation);

            return TerminalExpr.From(DfaProvision.From("string", @string));
        }
    }
}
