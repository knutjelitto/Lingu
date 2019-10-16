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
        protected abstract T OnAngrammar(INonterminalToken token);
        protected abstract T OnGrammarOptions(INonterminalToken token);
        protected abstract T OnOption(INonterminalToken token);
        protected abstract T OnGrammarRules(INonterminalToken token);
        protected abstract T OnRule(INonterminalToken token);
        protected abstract T OnRuleExpression(INonterminalToken token);
        protected abstract T OnRuleSequence(INonterminalToken token);
        protected abstract T OnRuleOptional(INonterminalToken token);
        protected abstract T OnRuleStarClosure(INonterminalToken token);
        protected abstract T OnRulePlusClosure(INonterminalToken token);
        protected abstract T OnRuleDropElement(INonterminalToken token);
        protected abstract T OnRulePromoteElement(INonterminalToken token);
        protected abstract T OnSubRule(INonterminalToken token);
        protected abstract T OnGrammarTerminals(INonterminalToken token);
        protected abstract T OnTerminalRule(INonterminalToken token);
        protected abstract T OnTerminalExpression(INonterminalToken token);
        protected abstract T OnTerminalDiff(INonterminalToken token);
        protected abstract T OnTerminalSequence(INonterminalToken token);
        protected abstract T OnTerminalOptional(INonterminalToken token);
        protected abstract T OnTerminalStarClosure(INonterminalToken token);
        protected abstract T OnTerminalPlusClosure(INonterminalToken token);
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
                LinguId.Angrammar => (TAst)OnAngrammar((INonterminalToken)token),
                LinguId.GrammarOptions => (TAst)OnGrammarOptions((INonterminalToken)token),
                LinguId.Option => (TAst)OnOption((INonterminalToken)token),
                LinguId.GrammarRules => (TAst)OnGrammarRules((INonterminalToken)token),
                LinguId.Rule => (TAst)OnRule((INonterminalToken)token),
                LinguId.RuleExpression => (TAst)OnRuleExpression((INonterminalToken)token),
                LinguId.RuleSequence => (TAst)OnRuleSequence((INonterminalToken)token),
                LinguId.RuleOptional => (TAst)OnRuleOptional((INonterminalToken)token),
                LinguId.RuleStarClosure => (TAst)OnRuleStarClosure((INonterminalToken)token),
                LinguId.RulePlusClosure => (TAst)OnRulePlusClosure((INonterminalToken)token),
                LinguId.RuleDropElement => (TAst)OnRuleDropElement((INonterminalToken)token),
                LinguId.RulePromoteElement => (TAst)OnRulePromoteElement((INonterminalToken)token),
                LinguId.SubRule => (TAst)OnSubRule((INonterminalToken)token),
                LinguId.GrammarTerminals => (TAst)OnGrammarTerminals((INonterminalToken)token),
                LinguId.TerminalRule => (TAst)OnTerminalRule((INonterminalToken)token),
                LinguId.TerminalExpression => (TAst)OnTerminalExpression((INonterminalToken)token),
                LinguId.TerminalDiff => (TAst)OnTerminalDiff((INonterminalToken)token),
                LinguId.TerminalSequence => (TAst)OnTerminalSequence((INonterminalToken)token),
                LinguId.TerminalOptional => (TAst)OnTerminalOptional((INonterminalToken)token),
                LinguId.TerminalStarClosure => (TAst)OnTerminalStarClosure((INonterminalToken)token),
                LinguId.TerminalPlusClosure => (TAst)OnTerminalPlusClosure((INonterminalToken)token),
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
        protected override T OnAngrammar(INonterminalToken token)
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
        protected override T OnRuleOptional(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRuleStarClosure(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRulePlusClosure(INonterminalToken token)
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
        protected override T OnTerminalOptional(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalStarClosure(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTerminalPlusClosure(INonterminalToken token)
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
        public const int Angrammar = 32;
        public const int GrammarOptions = 34;
        public const int Option = 35;
        public const int GrammarRules = 36;
        public const int Rule = 37;
        public const int RuleExpression = 38;
        public const int RuleSequence = 40;
        public const int RuleOptional = 42;
        public const int RuleStarClosure = 43;
        public const int RulePlusClosure = 44;
        public const int RuleDropElement = 46;
        public const int RulePromoteElement = 47;
        public const int SubRule = 49;
        public const int GrammarTerminals = 52;
        public const int TerminalRule = 53;
        public const int TerminalExpression = 54;
        public const int TerminalDiff = 56;
        public const int TerminalSequence = 57;
        public const int TerminalOptional = 59;
        public const int TerminalStarClosure = 60;
        public const int TerminalPlusClosure = 61;
        public const int TerminalRangeLoop = 62;
        public const int Range = 63;
        public const int TerminalNot = 65;
        public const int CharacterRange = 67;
    }
}
