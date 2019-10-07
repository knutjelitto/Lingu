namespace Lingu.CC
{
    using System;
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Lexing;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public class LinguVisitor
    {
        public abstract class AbstractVisitor<T>
        {
            public abstract W OnIdentifier<W>(IToken token) where W : T;
            public abstract W OnNumber<W>(IToken token) where W : T;
            public abstract W OnAny<W>(IToken token) where W : T;
            public abstract W OnText<W>(IToken token) where W : T;
            public abstract W OnUcBlock<W>(IToken token) where W : T;
            public abstract W OnUcCategory<W>(IToken token) where W : T;
            public abstract W OnUcCodepoint<W>(IToken token) where W : T;
            public abstract W OnFile<W>(IToken token) where W : T;
            public abstract W OnAngrammar<W>(IToken token) where W : T;
            public abstract W OnGrammarItem<W>(IToken token) where W : T;
            public abstract W OnGrammarOptions<W>(IToken token) where W : T;
            public abstract W OnOption<W>(IToken token) where W : T;
            public abstract W OnGrammarRules<W>(IToken token) where W : T;
            public abstract W OnRule<W>(IToken token) where W : T;
            public abstract W OnRuleExpression<W>(IToken token) where W : T;
            public abstract W OnRuleAlternative<W>(IToken token) where W : T;
            public abstract W OnRuleSequence<W>(IToken token) where W : T;
            public abstract W OnRuleRepetition<W>(IToken token) where W : T;
            public abstract W OnRuleOptional<W>(IToken token) where W : T;
            public abstract W OnRuleStarClosure<W>(IToken token) where W : T;
            public abstract W OnRulePlusClosure<W>(IToken token) where W : T;
            public abstract W OnRuleTreeAction<W>(IToken token) where W : T;
            public abstract W OnRuleDropElement<W>(IToken token) where W : T;
            public abstract W OnRulePromoteElement<W>(IToken token) where W : T;
            public abstract W OnRuleElement<W>(IToken token) where W : T;
            public abstract W OnSubRule<W>(IToken token) where W : T;
            public abstract W OnRuleAtom<W>(IToken token) where W : T;
            public abstract W OnReference<W>(IToken token) where W : T;
            public abstract W OnGrammarTerminals<W>(IToken token) where W : T;
            public abstract W OnTerminalRule<W>(IToken token) where W : T;
            public abstract W OnTerminalExpression<W>(IToken token) where W : T;
            public abstract W OnTerminalAlternative<W>(IToken token) where W : T;
            public abstract W OnTerminalDiff<W>(IToken token) where W : T;
            public abstract W OnTerminalSequence<W>(IToken token) where W : T;
            public abstract W OnTerminalRepetition<W>(IToken token) where W : T;
            public abstract W OnTerminalOptional<W>(IToken token) where W : T;
            public abstract W OnTerminalStarClosure<W>(IToken token) where W : T;
            public abstract W OnTerminalPlusClosure<W>(IToken token) where W : T;
            public abstract W OnTerminalRangeLoop<W>(IToken token) where W : T;
            public abstract W OnRange<W>(IToken token) where W : T;
            public abstract W OnTerminalElement<W>(IToken token) where W : T;
            public abstract W OnTerminalNot<W>(IToken token) where W : T;
            public abstract W OnTerminalAtom<W>(IToken token) where W : T;
            public abstract W OnCharacterRange<W>(IToken token) where W : T;
            public abstract W OnCharacter<W>(IToken token) where W : T;
            
            protected W Visit<W>(IToken token) where W : T
            {
                switch (token.Symbol.Id)
                {
                    case Id.Identifier: return OnIdentifier<W>(token);
                    case Id.Number: return OnNumber<W>(token);
                    case Id.Any: return OnAny<W>(token);
                    case Id.Text: return OnText<W>(token);
                    case Id.UcBlock: return OnUcBlock<W>(token);
                    case Id.UcCategory: return OnUcCategory<W>(token);
                    case Id.UcCodepoint: return OnUcCodepoint<W>(token);
                    case Id.File: return OnFile<W>(token);
                    case Id.Angrammar: return OnAngrammar<W>(token);
                    case Id.GrammarItem: return OnGrammarItem<W>(token);
                    case Id.GrammarOptions: return OnGrammarOptions<W>(token);
                    case Id.Option: return OnOption<W>(token);
                    case Id.GrammarRules: return OnGrammarRules<W>(token);
                    case Id.Rule: return OnRule<W>(token);
                    case Id.RuleExpression: return OnRuleExpression<W>(token);
                    case Id.RuleAlternative: return OnRuleAlternative<W>(token);
                    case Id.RuleSequence: return OnRuleSequence<W>(token);
                    case Id.RuleRepetition: return OnRuleRepetition<W>(token);
                    case Id.RuleOptional: return OnRuleOptional<W>(token);
                    case Id.RuleStarClosure: return OnRuleStarClosure<W>(token);
                    case Id.RulePlusClosure: return OnRulePlusClosure<W>(token);
                    case Id.RuleTreeAction: return OnRuleTreeAction<W>(token);
                    case Id.RuleDropElement: return OnRuleDropElement<W>(token);
                    case Id.RulePromoteElement: return OnRulePromoteElement<W>(token);
                    case Id.RuleElement: return OnRuleElement<W>(token);
                    case Id.SubRule: return OnSubRule<W>(token);
                    case Id.RuleAtom: return OnRuleAtom<W>(token);
                    case Id.Reference: return OnReference<W>(token);
                    case Id.GrammarTerminals: return OnGrammarTerminals<W>(token);
                    case Id.TerminalRule: return OnTerminalRule<W>(token);
                    case Id.TerminalExpression: return OnTerminalExpression<W>(token);
                    case Id.TerminalAlternative: return OnTerminalAlternative<W>(token);
                    case Id.TerminalDiff: return OnTerminalDiff<W>(token);
                    case Id.TerminalSequence: return OnTerminalSequence<W>(token);
                    case Id.TerminalRepetition: return OnTerminalRepetition<W>(token);
                    case Id.TerminalOptional: return OnTerminalOptional<W>(token);
                    case Id.TerminalStarClosure: return OnTerminalStarClosure<W>(token);
                    case Id.TerminalPlusClosure: return OnTerminalPlusClosure<W>(token);
                    case Id.TerminalRangeLoop: return OnTerminalRangeLoop<W>(token);
                    case Id.Range: return OnRange<W>(token);
                    case Id.TerminalElement: return OnTerminalElement<W>(token);
                    case Id.TerminalNot: return OnTerminalNot<W>(token);
                    case Id.TerminalAtom: return OnTerminalAtom<W>(token);
                    case Id.CharacterRange: return OnCharacterRange<W>(token);
                    case Id.Character: return OnCharacter<W>(token);
                }
                
                throw new System.NotImplementedException();
            }
            
            protected abstract W Default<W>(IToken token) where W : T;
        }
        
        public abstract class Visitor<T> : AbstractVisitor<T>
        {
            public override W OnIdentifier<W>(IToken token) { return Default<W>(token); }
            public override W OnNumber<W>(IToken token) { return Default<W>(token); }
            public override W OnAny<W>(IToken token) { return Default<W>(token); }
            public override W OnText<W>(IToken token) { return Default<W>(token); }
            public override W OnUcBlock<W>(IToken token) { return Default<W>(token); }
            public override W OnUcCategory<W>(IToken token) { return Default<W>(token); }
            public override W OnUcCodepoint<W>(IToken token) { return Default<W>(token); }
            public override W OnFile<W>(IToken token) { return Default<W>(token); }
            public override W OnAngrammar<W>(IToken token) { return Default<W>(token); }
            public override W OnGrammarItem<W>(IToken token) { return Default<W>(token); }
            public override W OnGrammarOptions<W>(IToken token) { return Default<W>(token); }
            public override W OnOption<W>(IToken token) { return Default<W>(token); }
            public override W OnGrammarRules<W>(IToken token) { return Default<W>(token); }
            public override W OnRule<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleExpression<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleAlternative<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleSequence<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleRepetition<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleOptional<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleStarClosure<W>(IToken token) { return Default<W>(token); }
            public override W OnRulePlusClosure<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleTreeAction<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleDropElement<W>(IToken token) { return Default<W>(token); }
            public override W OnRulePromoteElement<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleElement<W>(IToken token) { return Default<W>(token); }
            public override W OnSubRule<W>(IToken token) { return Default<W>(token); }
            public override W OnRuleAtom<W>(IToken token) { return Default<W>(token); }
            public override W OnReference<W>(IToken token) { return Default<W>(token); }
            public override W OnGrammarTerminals<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalRule<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalExpression<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalAlternative<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalDiff<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalSequence<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalRepetition<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalOptional<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalStarClosure<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalPlusClosure<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalRangeLoop<W>(IToken token) { return Default<W>(token); }
            public override W OnRange<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalElement<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalNot<W>(IToken token) { return Default<W>(token); }
            public override W OnTerminalAtom<W>(IToken token) { return Default<W>(token); }
            public override W OnCharacterRange<W>(IToken token) { return Default<W>(token); }
            public override W OnCharacter<W>(IToken token) { return Default<W>(token); }
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
            public const int File = 29;
            public const int Angrammar = 30;
            public const int GrammarItem = 31;
            public const int GrammarOptions = 32;
            public const int Option = 33;
            public const int GrammarRules = 34;
            public const int Rule = 35;
            public const int RuleExpression = 36;
            public const int RuleAlternative = 37;
            public const int RuleSequence = 38;
            public const int RuleRepetition = 39;
            public const int RuleOptional = 40;
            public const int RuleStarClosure = 41;
            public const int RulePlusClosure = 42;
            public const int RuleTreeAction = 43;
            public const int RuleDropElement = 44;
            public const int RulePromoteElement = 45;
            public const int RuleElement = 46;
            public const int SubRule = 47;
            public const int RuleAtom = 48;
            public const int Reference = 49;
            public const int GrammarTerminals = 50;
            public const int TerminalRule = 51;
            public const int TerminalExpression = 52;
            public const int TerminalAlternative = 53;
            public const int TerminalDiff = 54;
            public const int TerminalSequence = 55;
            public const int TerminalRepetition = 56;
            public const int TerminalOptional = 57;
            public const int TerminalStarClosure = 58;
            public const int TerminalPlusClosure = 59;
            public const int TerminalRangeLoop = 60;
            public const int Range = 61;
            public const int TerminalElement = 62;
            public const int TerminalNot = 63;
            public const int TerminalAtom = 64;
            public const int CharacterRange = 65;
            public const int Character = 66;
        }
    }
}
