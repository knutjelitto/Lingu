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

        private readonly Lazy<Terminal> lazySeparator;
        private readonly Lazy<Terminal> lazyNewline;
        private readonly Lazy<Nonterminal> lazyStart;

        public Options(TreeGrammar grammar)
        {
            lazySeparator = new Lazy<Terminal>(() =>
            {
                if (grammar.TreeOptions.TryGetValue(SeparatorId, out var option))
                {
                    if (grammar.Terminals.TryGetValue(option.Value, out var terminal))
                    {
                        return terminal;
                    }
                    throw new GrammarException($"option `{SeparatorId}´: no such terminal rule `{option.Value}´");
                }
                return null;
            });
            lazyNewline = new Lazy<Terminal>(() =>
            {
                if (grammar.TreeOptions.TryGetValue(NewlineId, out var option))
                {
                    if (grammar.Terminals.TryGetValue(option.Value, out var terminal))
                    {
                        return terminal;
                    }
                    throw new GrammarException($"option `{NewlineId}´: no such terminal rule `{option.Value}´");
                }
                return null;
            });
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
            Grammar = grammar;
        }

        public Terminal Separator => lazySeparator.Value;
        public Terminal Newline => lazyNewline.Value;
        public Nonterminal Start => lazyStart.Value;

        public TreeGrammar Grammar { get; }
    }
}
