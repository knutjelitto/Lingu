using System;

using Lingu.Errors;

#nullable enable

namespace Lingu.Grammars
{
    public class OptionsMaker
    {
        private readonly Symbol WhitespaceId = (Symbol)"Whitespace";
        private readonly Symbol NewlineId = (Symbol)"Newline";
        private readonly Symbol StartId = (Symbol)"Start";
        private readonly Symbol KeywordsId = (Symbol)"Keywords";

        private readonly Lazy<Terminal?> lazyWhitespace;
        private readonly Lazy<Terminal?> lazyNewline;
        private readonly Lazy<Terminal?> lazyKeywords;
        private readonly Lazy<Nonterminal?> lazyStart;

        public OptionsMaker(Grammar grammar)
        {
            Grammar = grammar;

            lazyWhitespace = new Lazy<Terminal?>(() => FindTerminal(WhitespaceId));
            lazyNewline = new Lazy<Terminal?>(() => FindTerminal(NewlineId));
            lazyKeywords = new Lazy<Terminal?>(() => FindTerminal(KeywordsId));
            lazyStart = new Lazy<Nonterminal?>(() => FindNonterminal(StartId));
        }

        public Terminal? Whitespace => lazyWhitespace.Value;
        public Terminal? Newline => lazyNewline.Value;
        public Terminal? Keywords => lazyKeywords.Value;
        public Nonterminal? Start => lazyStart.Value;

        public Grammar Grammar { get; }

        private Terminal? FindTerminal(Symbol id)
        {
            if (Grammar.OptionList.TryGetValue(id, out var option))
            {
                if (Grammar.Terminals.TryGetValue(option.Value, out var terminal))
                {
                    return terminal;
                }
                throw new GrammarException($"option `{id}´: no such terminal rule `{option.Value}´");
            }
            return null;
        }

        private Nonterminal? FindNonterminal(Symbol id)
        {
            if (Grammar.OptionList.TryGetValue(id, out var option))
            {
                if (Grammar.Nonterminals.TryGetValue(option.Value, out var nonterminal))
                {
                    return nonterminal;
                }
                throw new GrammarException($"option `{id}´: no such nonterminal rule `{option.Value}´");
            }
            return null;
        }
    }
}
