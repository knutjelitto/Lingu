using Lingu.Automata;
using Lingu.GrammarsOld;
using Lingu.GrammarsOld.Build;

namespace Lingu.Samples.Expr
{
    // ReSharper disable once UnusedMember.Global
    public class ExprGrammar
    {
        public static Grammar Create()
        {
            RuleExpr Expr = "Expr";
            RuleExpr Sum = "Sum";
            RuleExpr Product = "Product";
            RuleExpr Factor = "Factor";
            RuleExpr Primary = "Primary";
            RuleExpr Number = "Number";

            Expr.Body = Sum;

            Sum.Body = 
                (Sum + '+' + Product) |
                (Sum + '-' + Product) |
                Product;

            Product.Body =
                (Product + '*' + Factor) |
                (Product + '/' + Factor) |
                Factor;

            Factor.Body = Primary;

            Primary.Body =
                ('(' + Sum + ')') |
                Number;

            Number.Body = NumberTerminal();

            return new GrammarBuilder().From(Expr);
        }

        private static TerminalExpr NumberTerminal()
        {
            // [-+]?[0-9]+

            var digit = FA.From('0', '9');
            var sign = FA.Or(FA.From('+'), FA.From('-'));

            var number = FA.And(sign.Opt(), digit.Plus());

            return TerminalExpr.From(DfaProvision.From("number", number));
        }
    }
}
