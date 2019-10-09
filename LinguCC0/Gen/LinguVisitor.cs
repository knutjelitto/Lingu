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
            public abstract T OnAngrammar(INonterminalToken token);
            public abstract T OnGrammarOptions(INonterminalToken token);
            public abstract T OnOption(INonterminalToken token);
            public abstract T OnGrammarRules(INonterminalToken token);
            public abstract T OnRule(INonterminalToken token);
            public abstract T OnRuleExpression(INonterminalToken token);
            public abstract T OnRuleSequence(INonterminalToken token);
            public abstract T OnRuleOption(INonterminalToken token);
            public abstract T OnRuleStar(INonterminalToken token);
            public abstract T OnRulePlus(INonterminalToken token);
            public abstract T OnRuleDrop(INonterminalToken token);
            public abstract T OnRulePromote(INonterminalToken token);
            public abstract T OnSubRule(INonterminalToken token);
            public abstract T OnGrammarTerminals(INonterminalToken token);
            public abstract T OnTerminalRule(INonterminalToken token);
            public abstract T OnTerminalExpression(INonterminalToken token);
            public abstract T OnTerminalDiff(INonterminalToken token);
            public abstract T OnTerminalSequence(INonterminalToken token);
            public abstract T OnTerminalOptional(INonterminalToken token);
            public abstract T OnTerminalStarClosure(INonterminalToken token);
            public abstract T OnTerminalPlusClosure(INonterminalToken token);
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
                    Id.Angrammar => (W)OnAngrammar((INonterminalToken)token),
                    Id.GrammarOptions => (W)OnGrammarOptions((INonterminalToken)token),
                    Id.Option => (W)OnOption((INonterminalToken)token),
                    Id.GrammarRules => (W)OnGrammarRules((INonterminalToken)token),
                    Id.Rule => (W)OnRule((INonterminalToken)token),
                    Id.RuleExpression => (W)OnRuleExpression((INonterminalToken)token),
                    Id.RuleSequence => (W)OnRuleSequence((INonterminalToken)token),
                    Id.RuleOption => (W)OnRuleOption((INonterminalToken)token),
                    Id.RuleStar => (W)OnRuleStar((INonterminalToken)token),
                    Id.RulePlus => (W)OnRulePlus((INonterminalToken)token),
                    Id.RuleDrop => (W)OnRuleDrop((INonterminalToken)token),
                    Id.RulePromote => (W)OnRulePromote((INonterminalToken)token),
                    Id.SubRule => (W)OnSubRule((INonterminalToken)token),
                    Id.GrammarTerminals => (W)OnGrammarTerminals((INonterminalToken)token),
                    Id.TerminalRule => (W)OnTerminalRule((INonterminalToken)token),
                    Id.TerminalExpression => (W)OnTerminalExpression((INonterminalToken)token),
                    Id.TerminalDiff => (W)OnTerminalDiff((INonterminalToken)token),
                    Id.TerminalSequence => (W)OnTerminalSequence((INonterminalToken)token),
                    Id.TerminalOptional => (W)OnTerminalOptional((INonterminalToken)token),
                    Id.TerminalStarClosure => (W)OnTerminalStarClosure((INonterminalToken)token),
                    Id.TerminalPlusClosure => (W)OnTerminalPlusClosure((INonterminalToken)token),
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
            public override T OnAngrammar(INonterminalToken token) { return Default(token); }
            public override T OnGrammarOptions(INonterminalToken token) { return Default(token); }
            public override T OnOption(INonterminalToken token) { return Default(token); }
            public override T OnGrammarRules(INonterminalToken token) { return Default(token); }
            public override T OnRule(INonterminalToken token) { return Default(token); }
            public override T OnRuleExpression(INonterminalToken token) { return Default(token); }
            public override T OnRuleSequence(INonterminalToken token) { return Default(token); }
            public override T OnRuleOption(INonterminalToken token) { return Default(token); }
            public override T OnRuleStar(INonterminalToken token) { return Default(token); }
            public override T OnRulePlus(INonterminalToken token) { return Default(token); }
            public override T OnRuleDrop(INonterminalToken token) { return Default(token); }
            public override T OnRulePromote(INonterminalToken token) { return Default(token); }
            public override T OnSubRule(INonterminalToken token) { return Default(token); }
            public override T OnGrammarTerminals(INonterminalToken token) { return Default(token); }
            public override T OnTerminalRule(INonterminalToken token) { return Default(token); }
            public override T OnTerminalExpression(INonterminalToken token) { return Default(token); }
            public override T OnTerminalDiff(INonterminalToken token) { return Default(token); }
            public override T OnTerminalSequence(INonterminalToken token) { return Default(token); }
            public override T OnTerminalOptional(INonterminalToken token) { return Default(token); }
            public override T OnTerminalStarClosure(INonterminalToken token) { return Default(token); }
            public override T OnTerminalPlusClosure(INonterminalToken token) { return Default(token); }
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
            public const int File = 33;
            public const int Angrammar = 34;
            public const int GrammarOptions = 36;
            public const int Option = 37;
            public const int GrammarRules = 38;
            public const int Rule = 39;
            public const int RuleExpression = 40;
            public const int RuleSequence = 42;
            public const int RuleOption = 44;
            public const int RuleStar = 45;
            public const int RulePlus = 46;
            public const int RuleDrop = 48;
            public const int RulePromote = 49;
            public const int SubRule = 51;
            public const int GrammarTerminals = 54;
            public const int TerminalRule = 55;
            public const int TerminalExpression = 56;
            public const int TerminalDiff = 58;
            public const int TerminalSequence = 59;
            public const int TerminalOptional = 61;
            public const int TerminalStarClosure = 62;
            public const int TerminalPlusClosure = 63;
            public const int TerminalRangeLoop = 64;
            public const int Range = 65;
            public const int TerminalNot = 67;
            public const int CharacterRange = 69;
        }
    }
}
