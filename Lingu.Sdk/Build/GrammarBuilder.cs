using System.Linq;

using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Tree;

#nullable enable

namespace Lingu.Build
{
    public class GrammarBuilder
    {
        public GrammarBuilder(RawGrammar tree)
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

            var pid = 0;
            foreach (var t in Grammar.Terminals)
            {
                if (!t.IsPrivate)
                {
                    t.Pid = pid;
                    pid += 1;
                }
            }
            foreach (var n in Grammar.Nonterminals)
            {
                if (!ReferenceEquals(n, Grammar.Accept))
                {
                    n.Pid = pid;
                    pid += 1;
                }
            }

            var symbols = Grammar.Terminals.Concat<Symbol>(Grammar.Nonterminals).ToList();

            symbols.Sort((s1, s2) =>
            {
                if (s1.IsPid && s2.IsPid)
                {
                    return s1.Pid.CompareTo(s2.Pid);
                }
                if (!s1.IsPid && !s2.IsPid)
                {
                    return s1.Id.CompareTo(s2.Id);
                }
                if (s1.IsPid)
                {
                    return -1;
                }
                return 1;
            });

            Grammar.Symbols = symbols.Select((s, i) => { s.Id = i; return s; }).ToArray();
            Grammar.PSymbols = Grammar.Symbols.Where(s => s.IsPid).ToArray();

            new SetsBuilder(Grammar).Build();

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
