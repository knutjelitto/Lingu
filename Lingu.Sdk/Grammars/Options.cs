using System;

using Lingu.Errors;
using Lingu.Tree;

namespace Lingu.Grammars
{
    public class Options
    {
        private readonly Symbol SeparatorId = (Symbol)"Separator";
        private readonly Symbol NewlineId = (Symbol)"Newline";
        private readonly Symbol StartId = (Symbol)"Start";
        private readonly Symbol KeywordsId = (Symbol)"Keywords";

        private readonly Lazy<Terminal> lazySeparator;
        private readonly Lazy<Terminal> lazyNewline;
        private readonly Lazy<Terminal> lazyKeywords;
        private readonly Lazy<Nonterminal> lazyStart;

        public Options(TreeGrammar grammar)
        {
            Grammar = grammar;

            lazySeparator = new Lazy<Terminal>(() => FindTerminal(SeparatorId));
            lazyNewline = new Lazy<Terminal>(() => FindTerminal(NewlineId));
            lazyKeywords = new Lazy<Terminal>(() => FindTerminal(KeywordsId));

            lazyStart = new Lazy<Nonterminal>(() =>
            {
                if (grammar.TreeOptions.TryGetValue(StartId, out var option))
                {
                    if (grammar.Nonterminals.TryGetValue(option.Value, out var nonterminal))
                    {
                        return nonterminal;
                    }
                    throw new GrammarException($"option `{StartId}´: no such nonterminal rule `{option.Value}´");
                }
                return grammar.Nonterminals[0];
            });
        }

        public Terminal Separator => lazySeparator.Value;
        public Terminal Newline => lazyNewline.Value;
        public Terminal Keywords => lazyKeywords.Value;
        public Nonterminal Start => lazyStart.Value;

        public TreeGrammar Grammar { get; }

        private Terminal FindTerminal(Symbol id)
        {
            if (Grammar.TreeOptions.TryGetValue(id, out var option))
            {
                if (Grammar.Terminals.TryGetValue(option.Value, out var terminal))
                {
                    return terminal;
                }
                throw new GrammarException($"option `{id}´: no such terminal rule `{option.Value}´");
            }
            return null;
        }
    }
}
