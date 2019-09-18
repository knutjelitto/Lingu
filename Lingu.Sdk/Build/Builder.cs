using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Tree;

#nullable enable

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

            var setsBuilder = new SetsBuilder(Grammar);

            setsBuilder.Build();

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
                if (Grammar.OptionList.Contains(option))
                {
                    throw new GrammarException($"option: `{option.Name}´ already defined before");
                }
                Grammar.OptionList.Add(option);
            }
        }
    }
}
