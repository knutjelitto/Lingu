﻿using System;
using System.Collections.Generic;
using System.Text;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    public class Semantic
    {
        private Dictionary<Grammar, IGrammarAttributes> grammarAttributes = new Dictionary<Grammar, IGrammarAttributes>();
        private Dictionary<Rule, IRuleAttributes> ruleAttributes = new Dictionary<Rule, IRuleAttributes>();
        private Dictionary<Expression, IExpressionAttributes> expressionAttributes = new Dictionary<Expression, IExpressionAttributes>();

        public Semantic(Grammar grammar, ICompileResult results)
        {
            Grammar = grammar;
            Results = results;

            Rules = new UniqueCollection<string, Rule>(r => r.Identifier.Name, StringComparer.OrdinalIgnoreCase);
        }

        public Grammar Grammar { get; }
        public ICompileResult Results { get; }

        public UniqueCollection<string, Rule> Rules { get; }

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
        public IRuleAttributes this[Rule rule]
        {
            get
            {
                if (!ruleAttributes.TryGetValue(rule, out var attributes))
                {
                    attributes = new RuleAttribute();
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
                    attributes = new ExpressionAttribute();
                    expressionAttributes.Add(expression, attributes);
                }

                return attributes;
            }
        }
    }
}
