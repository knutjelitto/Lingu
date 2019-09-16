using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Runtime.LexDfa;
using Lingu.Tree;

namespace Lingu.Build
{
    public class Builder
    {
        public Builder(RawGrammar tree)
        {
            Raw = tree;
            Grammar = new Grammar(Raw.Name);
        }

        public RawGrammar Raw { get; }
        public Grammar Grammar { get; }

        public Grammar Build()
        {
            BuildOptions();

            var terminalBuilder = new TerminalBuilder(Grammar, Raw);
            var nonterminalBuilder = new NonterminalBuilder(Grammar, Raw);

            terminalBuilder.BuildPass1();

            nonterminalBuilder.BuildPass1();

            terminalBuilder.BuildPass2();

            nonterminalBuilder.BuildPass2();

            return Grammar;
        }

        /// <summary>
        /// Simply build options
        /// </summary>
        private void BuildOptions()
        {
            foreach (var raw in Raw.Options)
            {
                var option = raw;
                if (Grammar.Options.Contains(option))
                {
                    throw new GrammarException($"option: `{option.Name}´ already defined before");
                }
                Grammar.Options.Add(option);
            }
        }
    }
}
