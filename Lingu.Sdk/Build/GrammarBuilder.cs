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
            RawGrammar = tree;
            BuildGrammar = new BuildGrammar(RawGrammar.Name);
        }

        public RawGrammar RawGrammar { get; }
        public BuildGrammar BuildGrammar { get; }

        public Grammar Build()
        {
            BuildOptions();

            var terminalBuilder = new TerminalBuilder(BuildGrammar, RawGrammar);
            var nonterminalBuilder = new NonterminalBuilder(BuildGrammar, RawGrammar);

            terminalBuilder.BuildPass1();
            nonterminalBuilder.BuildPass1();
            terminalBuilder.BuildPass2();
            nonterminalBuilder.BuildPass2();

            var pid = 0;
            foreach (var t in BuildGrammar.Terminals)
            {
                if (!t.IsPrivate)
                {
                    t.Pid = pid;
                    pid += 1;
                }
            }
            foreach (var n in BuildGrammar.Nonterminals)
            {
                if (!ReferenceEquals(n, BuildGrammar.Accept))
                {
                    n.Pid = pid;
                    pid += 1;
                }
            }

            var symbols = BuildGrammar.Terminals.Concat<Symbol>(BuildGrammar.Nonterminals).ToList();

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

            BuildGrammar.Symbols = symbols.Select((s, i) => { s.Id = i; return s; }).ToArray();
            BuildGrammar.PSymbols = BuildGrammar.Symbols.Where(s => s.IsPid).ToArray();

            new SetsBuilder(BuildGrammar).Build();

            return BuildGrammar;
        }

        /// <summary>
        /// Simply build options
        /// </summary>
        private void BuildOptions()
        {
            foreach (var raw in RawGrammar.Options)
            {
                var option = raw;
                if (BuildGrammar.OptionList.Contains(option))
                {
                    throw new GrammarException($"option: `{option.Name}´ already defined before");
                }
                BuildGrammar.OptionList.Add(option);
            }
        }
    }
}
