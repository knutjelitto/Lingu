using System;
using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    public class Semantic
    {
        private Dictionary<Grammar, IGrammarAttributes> grammarAttributes = new Dictionary<Grammar, IGrammarAttributes>();
        private Dictionary<IRule, IRuleAttributes> ruleAttributes = new Dictionary<IRule, IRuleAttributes>();
        private Dictionary<Expression, IExpressionAttributes> expressionAttributes = new Dictionary<Expression, IExpressionAttributes>();

        public Semantic(Grammar grammar, ICompileResult results)
        {
            Grammar = grammar;
            Results = results;

            Rules = new UniqueCollection<string, IRule>(r => r.Identifier.Name, StringComparer.OrdinalIgnoreCase);
        }

        public Grammar Grammar { get; }
        public ICompileResult Results { get; }

        public UniqueCollection<string, IRule> Rules { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1043:Use Integral Or String Argument For Indexers", Justification = "<Pending>")]
        public IGrammarAttributes this[Grammar grammar]
        {
            get
            {
                if (!grammarAttributes.TryGetValue(grammar, out var attributes))
                {
                    attributes = new GrammarAttribute();
                    grammarAttributes.Add(grammar, attributes);
                }

                return attributes;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1043:Use Integral Or String Argument For Indexers", Justification = "<Pending>")]
        public IRuleAttributes this[IRule rule]
        {
            get
            {
                if (!ruleAttributes.TryGetValue(rule, out var attributes))
                {
                    attributes = new RuleAttributes();
                    ruleAttributes.Add(rule, attributes);
                }

                return attributes;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1043:Use Integral Or String Argument For Indexers", Justification = "<Pending>")]
        public IExpressionAttributes this[Expression expression]
        {
            get
            {
                if (!expressionAttributes.TryGetValue(expression, out var attributes))
                {
                    attributes = new ExpressionAttributes();
                    expressionAttributes.Add(expression, attributes);
                }

                return attributes;
            }
        }
    }
}
