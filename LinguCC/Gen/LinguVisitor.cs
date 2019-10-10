namespace Lingu.CC
{
    using System;
    using Lingu.Runtime.Structures;
    
    public class LinguVisitor
    {
        public abstract class AbstractVisitor<T> where T : class
        {
            public abstract T OnIdentifier(ITerminalToken token);
            public abstract T OnNumber(ITerminalToken token);
            public abstract T OnAny(ITerminalToken token);
            public abstract T OnText(ITerminalToken token);
            public abstract T OnUcBlock(ITerminalToken token);
            public abstract T OnUcCategory(ITerminalToken token);
            public abstract T OnUcCodepoint(ITerminalToken token);
            public abstract T OnFile(INonterminalToken token);
            public abstract T OnGrammar(INonterminalToken token);
            public abstract T OnGrammarOptions(INonterminalToken token);
            public abstract T OnOption(INonterminalToken token);
            public abstract T OnGrammarRules(INonterminalToken token);
            public abstract T OnRule(INonterminalToken token);
            public abstract T OnRuleExpression(INonterminalToken token);
            public abstract T OnRuleSequence(INonterminalToken token);
            public abstract T OnRuleOption(INonterminalToken token);
            public abstract T OnRuleStar(INonterminalToken token);
            public abstract T OnRulePlus(INonterminalToken token);
            public abstract T OnRuleDropElement(INonterminalToken token);
            public abstract T OnRulePromoteElement(INonterminalToken token);
            public abstract T OnSubRule(INonterminalToken token);
            public abstract T OnGrammarTerminals(INonterminalToken token);
            public abstract T OnTerminalRule(INonterminalToken token);
            public abstract T OnTerminalExpression(INonterminalToken token);
            public abstract T OnTerminalDiff(INonterminalToken token);
            public abstract T OnTerminalSequence(INonterminalToken token);
            public abstract T OnTerminalOption(INonterminalToken token);
            public abstract T OnTerminalStar(INonterminalToken token);
            public abstract T OnTerminalPlus(INonterminalToken token);
            public abstract T OnTerminalRangeLoop(INonterminalToken token);
            public abstract T OnRange(INonterminalToken token);
            public abstract T OnTerminalNot(INonterminalToken token);
            public abstract T OnCharacterRange(INonterminalToken token);
            
            protected W Visit<W>(IToken token) where W : T
            {
                return token.Symbol.Id switch
                {
                    Id.Identifier => (W)OnIdentifier((ITerminalToken)token),
                    Id.Number => (W)OnNumber((ITerminalToken)token),
                    Id.Any => (W)OnAny((ITerminalToken)token),
                    Id.Text => (W)OnText((ITerminalToken)token),
                    Id.UcBlock => (W)OnUcBlock((ITerminalToken)token),
                    Id.UcCategory => (W)OnUcCategory((ITerminalToken)token),
                    Id.UcCodepoint => (W)OnUcCodepoint((ITerminalToken)token),
                    Id.File => (W)OnFile((INonterminalToken)token),
                    Id.Grammar => (W)OnGrammar((INonterminalToken)token),
                    Id.GrammarOptions => (W)OnGrammarOptions((INonterminalToken)token),
                    Id.Option => (W)OnOption((INonterminalToken)token),
                    Id.GrammarRules => (W)OnGrammarRules((INonterminalToken)token),
                    Id.Rule => (W)OnRule((INonterminalToken)token),
                    Id.RuleExpression => (W)OnRuleExpression((INonterminalToken)token),
                    Id.RuleSequence => (W)OnRuleSequence((INonterminalToken)token),
                    Id.RuleOption => (W)OnRuleOption((INonterminalToken)token),
                    Id.RuleStar => (W)OnRuleStar((INonterminalToken)token),
                    Id.RulePlus => (W)OnRulePlus((INonterminalToken)token),
                    Id.RuleDropElement => (W)OnRuleDropElement((INonterminalToken)token),
                    Id.RulePromoteElement => (W)OnRulePromoteElement((INonterminalToken)token),
                    Id.SubRule => (W)OnSubRule((INonterminalToken)token),
                    Id.GrammarTerminals => (W)OnGrammarTerminals((INonterminalToken)token),
                    Id.TerminalRule => (W)OnTerminalRule((INonterminalToken)token),
                    Id.TerminalExpression => (W)OnTerminalExpression((INonterminalToken)token),
                    Id.TerminalDiff => (W)OnTerminalDiff((INonterminalToken)token),
                    Id.TerminalSequence => (W)OnTerminalSequence((INonterminalToken)token),
                    Id.TerminalOption => (W)OnTerminalOption((INonterminalToken)token),
                    Id.TerminalStar => (W)OnTerminalStar((INonterminalToken)token),
                    Id.TerminalPlus => (W)OnTerminalPlus((INonterminalToken)token),
                    Id.TerminalRangeLoop => (W)OnTerminalRangeLoop((INonterminalToken)token),
                    Id.Range => (W)OnRange((INonterminalToken)token),
                    Id.TerminalNot => (W)OnTerminalNot((INonterminalToken)token),
                    Id.CharacterRange => (W)OnCharacterRange((INonterminalToken)token),
                    
                    _ => throw new NotImplementedException(),
                };
            }
            
            protected abstract T Default(IToken token);
        }
        
        public abstract class Visitor<T> : AbstractVisitor<T> where T : class
        {
            public override T OnIdentifier(ITerminalToken token) { return Default(token); }
            public override T OnNumber(ITerminalToken token) { return Default(token); }
            public override T OnAny(ITerminalToken token) { return Default(token); }
            public override T OnText(ITerminalToken token) { return Default(token); }
            public override T OnUcBlock(ITerminalToken token) { return Default(token); }
            public override T OnUcCategory(ITerminalToken token) { return Default(token); }
            public override T OnUcCodepoint(ITerminalToken token) { return Default(token); }
            public override T OnFile(INonterminalToken token) { return Default(token); }
            public override T OnGrammar(INonterminalToken token) { return Default(token); }
            public override T OnGrammarOptions(INonterminalToken token) { return Default(token); }
            public override T OnOption(INonterminalToken token) { return Default(token); }
            public override T OnGrammarRules(INonterminalToken token) { return Default(token); }
            public override T OnRule(INonterminalToken token) { return Default(token); }
            public override T OnRuleExpression(INonterminalToken token) { return Default(token); }
            public override T OnRuleSequence(INonterminalToken token) { return Default(token); }
            public override T OnRuleOption(INonterminalToken token) { return Default(token); }
            public override T OnRuleStar(INonterminalToken token) { return Default(token); }
            public override T OnRulePlus(INonterminalToken token) { return Default(token); }
            public override T OnRuleDropElement(INonterminalToken token) { return Default(token); }
            public override T OnRulePromoteElement(INonterminalToken token) { return Default(token); }
            public override T OnSubRule(INonterminalToken token) { return Default(token); }
            public override T OnGrammarTerminals(INonterminalToken token) { return Default(token); }
            public override T OnTerminalRule(INonterminalToken token) { return Default(token); }
            public override T OnTerminalExpression(INonterminalToken token) { return Default(token); }
            public override T OnTerminalDiff(INonterminalToken token) { return Default(token); }
            public override T OnTerminalSequence(INonterminalToken token) { return Default(token); }
            public override T OnTerminalOption(INonterminalToken token) { return Default(token); }
            public override T OnTerminalStar(INonterminalToken token) { return Default(token); }
            public override T OnTerminalPlus(INonterminalToken token) { return Default(token); }
            public override T OnTerminalRangeLoop(INonterminalToken token) { return Default(token); }
            public override T OnRange(INonterminalToken token) { return Default(token); }
            public override T OnTerminalNot(INonterminalToken token) { return Default(token); }
            public override T OnCharacterRange(INonterminalToken token) { return Default(token); }
        }
        
        public class Id
        {
            public const int Identifier = 0;
            public const int Number = 1;
            public const int Any = 2;
            public const int Text = 3;
            public const int UcBlock = 4;
            public const int UcCategory = 5;
            public const int UcCodepoint = 6;
            public const int File = 31;
            public const int Grammar = 32;
            public const int GrammarOptions = 34;
            public const int Option = 35;
            public const int GrammarRules = 36;
            public const int Rule = 37;
            public const int RuleExpression = 38;
            public const int RuleSequence = 40;
            public const int RuleOption = 42;
            public const int RuleStar = 43;
            public const int RulePlus = 44;
            public const int RuleDropElement = 46;
            public const int RulePromoteElement = 47;
            public const int SubRule = 49;
            public const int GrammarTerminals = 52;
            public const int TerminalRule = 53;
            public const int TerminalExpression = 54;
            public const int TerminalDiff = 56;
            public const int TerminalSequence = 57;
            public const int TerminalOption = 59;
            public const int TerminalStar = 60;
            public const int TerminalPlus = 61;
            public const int TerminalRangeLoop = 62;
            public const int Range = 63;
            public const int TerminalNot = 65;
            public const int CharacterRange = 67;
        }
    }
}
