namespace Lingu.CC
{
    using System;
    using Lingu.Runtime.Structures;
    
    public class LinguVisitor
    {
        public abstract class AbstractVisitor<T>
        {
            public abstract W OnIdentifier<W>(ITerminalToken token) where W : T;
            public abstract W OnNumber<W>(ITerminalToken token) where W : T;
            public abstract W OnAny<W>(ITerminalToken token) where W : T;
            public abstract W OnText<W>(ITerminalToken token) where W : T;
            public abstract W OnUcBlock<W>(ITerminalToken token) where W : T;
            public abstract W OnUcCategory<W>(ITerminalToken token) where W : T;
            public abstract W OnUcCodepoint<W>(ITerminalToken token) where W : T;
            public abstract W OnFile<W>(INonterminalToken token) where W : T;
            public abstract W OnAngrammar<W>(INonterminalToken token) where W : T;
            public abstract W OnGrammarItem<W>(INonterminalToken token) where W : T;
            public abstract W OnGrammarOptions<W>(INonterminalToken token) where W : T;
            public abstract W OnOption<W>(INonterminalToken token) where W : T;
            public abstract W OnGrammarRules<W>(INonterminalToken token) where W : T;
            public abstract W OnRule<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleExpression<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleAlternative<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleSequence<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleRepetition<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleOptional<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleStarClosure<W>(INonterminalToken token) where W : T;
            public abstract W OnRulePlusClosure<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleTreeAction<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleDropElement<W>(INonterminalToken token) where W : T;
            public abstract W OnRulePromoteElement<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleElement<W>(INonterminalToken token) where W : T;
            public abstract W OnSubRule<W>(INonterminalToken token) where W : T;
            public abstract W OnRuleAtom<W>(INonterminalToken token) where W : T;
            public abstract W OnReference<W>(INonterminalToken token) where W : T;
            public abstract W OnGrammarTerminals<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalRule<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalExpression<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalAlternative<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalDiff<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalSequence<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalRepetition<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalOptional<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalStarClosure<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalPlusClosure<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalRangeLoop<W>(INonterminalToken token) where W : T;
            public abstract W OnRange<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalElement<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalNot<W>(INonterminalToken token) where W : T;
            public abstract W OnTerminalAtom<W>(INonterminalToken token) where W : T;
            public abstract W OnCharacterRange<W>(INonterminalToken token) where W : T;
            public abstract W OnCharacter<W>(INonterminalToken token) where W : T;
            
            protected W Visit<W>(IToken token) where W : T
            {
                return token.Symbol.Id switch
                {
                    Id.Identifier => OnIdentifier<W>((ITerminalToken)token),
                    Id.Number => OnNumber<W>((ITerminalToken)token),
                    Id.Any => OnAny<W>((ITerminalToken)token),
                    Id.Text => OnText<W>((ITerminalToken)token),
                    Id.UcBlock => OnUcBlock<W>((ITerminalToken)token),
                    Id.UcCategory => OnUcCategory<W>((ITerminalToken)token),
                    Id.UcCodepoint => OnUcCodepoint<W>((ITerminalToken)token),
                    Id.File => OnFile<W>((INonterminalToken)token),
                    Id.Angrammar => OnAngrammar<W>((INonterminalToken)token),
                    Id.GrammarItem => OnGrammarItem<W>((INonterminalToken)token),
                    Id.GrammarOptions => OnGrammarOptions<W>((INonterminalToken)token),
                    Id.Option => OnOption<W>((INonterminalToken)token),
                    Id.GrammarRules => OnGrammarRules<W>((INonterminalToken)token),
                    Id.Rule => OnRule<W>((INonterminalToken)token),
                    Id.RuleExpression => OnRuleExpression<W>((INonterminalToken)token),
                    Id.RuleAlternative => OnRuleAlternative<W>((INonterminalToken)token),
                    Id.RuleSequence => OnRuleSequence<W>((INonterminalToken)token),
                    Id.RuleRepetition => OnRuleRepetition<W>((INonterminalToken)token),
                    Id.RuleOptional => OnRuleOptional<W>((INonterminalToken)token),
                    Id.RuleStarClosure => OnRuleStarClosure<W>((INonterminalToken)token),
                    Id.RulePlusClosure => OnRulePlusClosure<W>((INonterminalToken)token),
                    Id.RuleTreeAction => OnRuleTreeAction<W>((INonterminalToken)token),
                    Id.RuleDropElement => OnRuleDropElement<W>((INonterminalToken)token),
                    Id.RulePromoteElement => OnRulePromoteElement<W>((INonterminalToken)token),
                    Id.RuleElement => OnRuleElement<W>((INonterminalToken)token),
                    Id.SubRule => OnSubRule<W>((INonterminalToken)token),
                    Id.RuleAtom => OnRuleAtom<W>((INonterminalToken)token),
                    Id.Reference => OnReference<W>((INonterminalToken)token),
                    Id.GrammarTerminals => OnGrammarTerminals<W>((INonterminalToken)token),
                    Id.TerminalRule => OnTerminalRule<W>((INonterminalToken)token),
                    Id.TerminalExpression => OnTerminalExpression<W>((INonterminalToken)token),
                    Id.TerminalAlternative => OnTerminalAlternative<W>((INonterminalToken)token),
                    Id.TerminalDiff => OnTerminalDiff<W>((INonterminalToken)token),
                    Id.TerminalSequence => OnTerminalSequence<W>((INonterminalToken)token),
                    Id.TerminalRepetition => OnTerminalRepetition<W>((INonterminalToken)token),
                    Id.TerminalOptional => OnTerminalOptional<W>((INonterminalToken)token),
                    Id.TerminalStarClosure => OnTerminalStarClosure<W>((INonterminalToken)token),
                    Id.TerminalPlusClosure => OnTerminalPlusClosure<W>((INonterminalToken)token),
                    Id.TerminalRangeLoop => OnTerminalRangeLoop<W>((INonterminalToken)token),
                    Id.Range => OnRange<W>((INonterminalToken)token),
                    Id.TerminalElement => OnTerminalElement<W>((INonterminalToken)token),
                    Id.TerminalNot => OnTerminalNot<W>((INonterminalToken)token),
                    Id.TerminalAtom => OnTerminalAtom<W>((INonterminalToken)token),
                    Id.CharacterRange => OnCharacterRange<W>((INonterminalToken)token),
                    Id.Character => OnCharacter<W>((INonterminalToken)token),
                    
                    _ => throw new NotImplementedException(),
                };
            }
            
            protected abstract W Default<W>(IToken token) where W : T;
        }
        
        public abstract class Visitor<T> : AbstractVisitor<T>
        {
            public override W OnIdentifier<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnNumber<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnAny<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnText<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnUcBlock<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnUcCategory<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnUcCodepoint<W>(ITerminalToken token) { return Default<W>(token); }
            public override W OnFile<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnAngrammar<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnGrammarItem<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnGrammarOptions<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnOption<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnGrammarRules<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRule<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleExpression<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleAlternative<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleSequence<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleRepetition<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleOptional<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleStarClosure<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRulePlusClosure<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleTreeAction<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleDropElement<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRulePromoteElement<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleElement<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnSubRule<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRuleAtom<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnReference<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnGrammarTerminals<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalRule<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalExpression<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalAlternative<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalDiff<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalSequence<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalRepetition<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalOptional<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalStarClosure<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalPlusClosure<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalRangeLoop<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnRange<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalElement<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalNot<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnTerminalAtom<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnCharacterRange<W>(INonterminalToken token) { return Default<W>(token); }
            public override W OnCharacter<W>(INonterminalToken token) { return Default<W>(token); }
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
            public const int Angrammar = 32;
            public const int GrammarItem = 33;
            public const int GrammarOptions = 34;
            public const int Option = 35;
            public const int GrammarRules = 36;
            public const int Rule = 37;
            public const int RuleExpression = 38;
            public const int RuleAlternative = 39;
            public const int RuleSequence = 40;
            public const int RuleRepetition = 41;
            public const int RuleOptional = 42;
            public const int RuleStarClosure = 43;
            public const int RulePlusClosure = 44;
            public const int RuleTreeAction = 45;
            public const int RuleDropElement = 46;
            public const int RulePromoteElement = 47;
            public const int RuleElement = 48;
            public const int SubRule = 49;
            public const int RuleAtom = 50;
            public const int Reference = 51;
            public const int GrammarTerminals = 52;
            public const int TerminalRule = 53;
            public const int TerminalExpression = 54;
            public const int TerminalAlternative = 55;
            public const int TerminalDiff = 56;
            public const int TerminalSequence = 57;
            public const int TerminalRepetition = 58;
            public const int TerminalOptional = 59;
            public const int TerminalStarClosure = 60;
            public const int TerminalPlusClosure = 61;
            public const int TerminalRangeLoop = 62;
            public const int Range = 63;
            public const int TerminalElement = 64;
            public const int TerminalNot = 65;
            public const int TerminalAtom = 66;
            public const int CharacterRange = 67;
            public const int Character = 68;
        }
    }
}
