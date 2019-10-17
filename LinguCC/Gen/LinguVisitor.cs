namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractLinguVisitor<T> where T : class
    {
        protected abstract T OnIdentifier(ITerminalToken token);
        protected abstract T OnNumber(ITerminalToken token);
        protected abstract T OnAny(ITerminalToken token);
        protected abstract T OnText(ITerminalToken token);
        protected abstract T OnUcBlock(ITerminalToken token);
        protected abstract T OnUcCategory(ITerminalToken token);
        protected abstract T OnUcCodepoint(ITerminalToken token);
        protected abstract T OnFile(INonterminalToken token);
        protected abstract T OnGrammar(INonterminalToken token);
        protected abstract T OnGrammarOptions(INonterminalToken token);
        protected abstract T OnOption(INonterminalToken token);
        protected abstract T OnGrammarRules(INonterminalToken token);
        protected abstract T OnRule(INonterminalToken token);
        protected abstract T OnRuleExpression(INonterminalToken token);
        protected abstract T OnRuleSequence(INonterminalToken token);
        protected abstract T OnRuleOption(INonterminalToken token);
        protected abstract T OnRuleStar(INonterminalToken token);
        protected abstract T OnRulePlus(INonterminalToken token);
        protected abstract T OnRuleDropElement(INonterminalToken token);
        protected abstract T OnRulePromoteElement(INonterminalToken token);
        protected abstract T OnSubRule(INonterminalToken token);
        protected abstract T OnGrammarTerminals(INonterminalToken token);
        protected abstract T OnTerminalRule(INonterminalToken token);
        protected abstract T OnTerminalExpression(INonterminalToken token);
        protected abstract T OnTerminalDiff(INonterminalToken token);
        protected abstract T OnTerminalSequence(INonterminalToken token);
        protected abstract T OnTerminalOption(INonterminalToken token);
        protected abstract T OnTerminalStar(INonterminalToken token);
        protected abstract T OnTerminalPlus(INonterminalToken token);
        protected abstract T OnTerminalRangeLoop(INonterminalToken token);
        protected abstract T OnRange(INonterminalToken token);
        protected abstract T OnTerminalNot(INonterminalToken token);
        protected abstract T OnCharacterRange(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                LinguId.Identifier => (TAst)OnIdentifier((ITerminalToken)token),
                LinguId.Number => (TAst)OnNumber((ITerminalToken)token),
                LinguId.Any => (TAst)OnAny((ITerminalToken)token),
                LinguId.Text => (TAst)OnText((ITerminalToken)token),
                LinguId.UcBlock => (TAst)OnUcBlock((ITerminalToken)token),
                LinguId.UcCategory => (TAst)OnUcCategory((ITerminalToken)token),
                LinguId.UcCodepoint => (TAst)OnUcCodepoint((ITerminalToken)token),
                LinguId.File => (TAst)OnFile((INonterminalToken)token),
                LinguId.Grammar => (TAst)OnGrammar((INonterminalToken)token),
                LinguId.GrammarOptions => (TAst)OnGrammarOptions((INonterminalToken)token),
                LinguId.Option => (TAst)OnOption((INonterminalToken)token),
                LinguId.GrammarRules => (TAst)OnGrammarRules((INonterminalToken)token),
                LinguId.Rule => (TAst)OnRule((INonterminalToken)token),
                LinguId.RuleExpression => (TAst)OnRuleExpression((INonterminalToken)token),
                LinguId.RuleSequence => (TAst)OnRuleSequence((INonterminalToken)token),
                LinguId.RuleOption => (TAst)OnRuleOption((INonterminalToken)token),
                LinguId.RuleStar => (TAst)OnRuleStar((INonterminalToken)token),
                LinguId.RulePlus => (TAst)OnRulePlus((INonterminalToken)token),
                LinguId.RuleDropElement => (TAst)OnRuleDropElement((INonterminalToken)token),
                LinguId.RulePromoteElement => (TAst)OnRulePromoteElement((INonterminalToken)token),
                LinguId.SubRule => (TAst)OnSubRule((INonterminalToken)token),
                LinguId.GrammarTerminals => (TAst)OnGrammarTerminals((INonterminalToken)token),
                LinguId.TerminalRule => (TAst)OnTerminalRule((INonterminalToken)token),
                LinguId.TerminalExpression => (TAst)OnTerminalExpression((INonterminalToken)token),
                LinguId.TerminalDiff => (TAst)OnTerminalDiff((INonterminalToken)token),
                LinguId.TerminalSequence => (TAst)OnTerminalSequence((INonterminalToken)token),
                LinguId.TerminalOption => (TAst)OnTerminalOption((INonterminalToken)token),
                LinguId.TerminalStar => (TAst)OnTerminalStar((INonterminalToken)token),
                LinguId.TerminalPlus => (TAst)OnTerminalPlus((INonterminalToken)token),
                LinguId.TerminalRangeLoop => (TAst)OnTerminalRangeLoop((INonterminalToken)token),
                LinguId.Range => (TAst)OnRange((INonterminalToken)token),
                LinguId.TerminalNot => (TAst)OnTerminalNot((INonterminalToken)token),
                LinguId.CharacterRange => (TAst)OnCharacterRange((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class LinguVisitor<T> : AbstractLinguVisitor<T> where T : class
    {
        protected override T OnIdentifier(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnNumber(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnAny(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnText(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnUcBlock(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnUcCategory(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnUcCodepoint(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnFile(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnGrammar(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnGrammarOptions(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnOption(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnGrammarRules(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRule(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleExpression(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleSequence(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleOption(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleStar(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRulePlus(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleDropElement(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRulePromoteElement(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnSubRule(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnGrammarTerminals(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalRule(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalExpression(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalDiff(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalSequence(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalOption(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalStar(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalPlus(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalRangeLoop(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRange(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalNot(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnCharacterRange(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
    }
    
    public static class LinguId
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
        public const int RuleSequence = 39;
        public const int RuleOption = 41;
        public const int RuleStar = 42;
        public const int RulePlus = 43;
        public const int RuleDropElement = 45;
        public const int RulePromoteElement = 46;
        public const int SubRule = 48;
        public const int GrammarTerminals = 51;
        public const int TerminalRule = 52;
        public const int TerminalExpression = 53;
        public const int TerminalDiff = 55;
        public const int TerminalSequence = 56;
        public const int TerminalOption = 58;
        public const int TerminalStar = 59;
        public const int TerminalPlus = 60;
        public const int TerminalRangeLoop = 61;
        public const int Range = 62;
        public const int TerminalNot = 64;
        public const int CharacterRange = 66;
    }
}
