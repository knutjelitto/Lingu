namespace Lipeg.Command
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Lipeg.Runtime;
    
    public partial class LipegParser : ParserBase
    {
        protected override IContext __SkipSpace(IContext context)
        {
            return _(context).Next;
        }
        
        // start -> Start
        public IResult Start(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{NameExpression
                    var result = __Parse(Grammar, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{NameExpression
                        result = __Parse(Eof, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "start");
        }
        
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "grammar");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    current = __SkipSpace(current);
                    // {{NameExpression
                        result = __Parse(Identifier, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            current = __SkipSpace(current);
                            // {{StringLiteralExpression
                                result = __MatchString(current, "{");
                            // }}StringLiteralExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes2 = new List<INode>(10);
                                    for (;;)
                                    {
                                        // {{ChoiceExpression
                                            // {{NameExpression
                                                result = __Parse(Options, current);
                                            // }}NameExpression
                                            if (!result.IsSuccess)
                                            {
                                                // {{NameExpression
                                                    result = __Parse(Syntax, current);
                                                // }}NameExpression
                                                if (!result.IsSuccess)
                                                {
                                                    // {{NameExpression
                                                        result = __Parse(Lexical, current);
                                                    // }}NameExpression
                                                }
                                            }
                                        // }}ChoiceExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes2.AddRange(result.Nodes);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                // }}StarExpression
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes3.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{DropExpression
                                    current = __SkipSpace(current);
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "}");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                // }}DropExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "grammar");
        }
        
        // options -> Options
        public IResult Options(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "options");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "{");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{StarExpression
                                var start = current;
                                var nodes2 = new List<INode>(10);
                                for (;;)
                                {
                                    // {{NameExpression
                                        result = __Parse(Option, current);
                                    // }}NameExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes2.AddRange(result.Nodes);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            // }}StarExpression
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>(10);
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                current = __SkipSpace(current);
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "}");
                                // }}StringLiteralExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "options");
        }
        
        // option -> Option
        public IResult Option(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                // {{NameExpression
                    var result = __Parse(Identifier, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "=");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{NameExpression
                            result = __Parse(OptionValue, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                current = __SkipSpace(current);
                                // {{StringLiteralExpression
                                    result = __MatchString(current, ";");
                                // }}StringLiteralExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "option");
        }
        
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            var current = context;
            // {{NameExpression
                var result = __Parse(QualifiedIdentifier, current);
            // }}NameExpression
            return __FinishRule(result, "option-value");
        }
        
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                // {{NameExpression
                    var result = __Parse(Identifier, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{StarExpression
                            var start = current;
                            var nodes2 = new List<INode>(10);
                            for (;;)
                            {
                                // {{SequenceExpression
                                    var nodes3 = new List<INode>(10);
                                    // {{DropExpression
                                        current = __SkipSpace(current);
                                        // {{StringLiteralExpression
                                            result = __MatchString(current, ".");
                                        // }}StringLiteralExpression
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    // }}DropExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes3.AddRange(result.Nodes);
                                        current = __SkipSpace(current);
                                        // {{NameExpression
                                            result = __Parse(Identifier, current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes3.AddRange(result.Nodes);
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
                                    }
                                // }}SequenceExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes2.AddRange(result.Nodes);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var location = Location.From(start, current);
                            var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                            result = Result.Success(location, current, node);
                        // }}StarExpression
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>(10);
                            foreach (var node2 in result.Nodes)
                            {
                                nodes4.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "qualified-identifier");
        }
        
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "syntax");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "{");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{NameExpression
                                result = __Parse(Rules, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>(10);
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                // {{OptionalExpression
                                    current = __SkipSpace(current);
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, ";");
                                    // }}StringLiteralExpression
                                    var node2 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node2);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node2);
                                    }
                                // }}OptionalExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{DropExpression
                                    current = __SkipSpace(current);
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "}");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                // }}DropExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "syntax");
        }
        
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "lexical");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "{");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{NameExpression
                                result = __Parse(Rules, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>(10);
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                // {{OptionalExpression
                                    current = __SkipSpace(current);
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, ";");
                                    // }}StringLiteralExpression
                                    var node2 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node2);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node2);
                                    }
                                // }}OptionalExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{DropExpression
                                    current = __SkipSpace(current);
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "}");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                // }}DropExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "lexical");
        }
        
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{OptionalExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>(10);
                        // {{NameExpression
                            var result = __Parse(Rule, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes2 = new List<INode>(10);
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes3 = new List<INode>(10);
                                            // {{DropExpression
                                                current = __SkipSpace(current);
                                                // {{StringLiteralExpression
                                                    result = __MatchString(current, ";");
                                                // }}StringLiteralExpression
                                                if (result.IsSuccess)
                                                {
                                                    result = Result.Success(result, result.Next);
                                                }
                                            // }}DropExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes3.AddRange(result.Nodes);
                                                // {{NameExpression
                                                    result = __Parse(Rule, current);
                                                // }}NameExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes3.AddRange(result.Nodes);
                                                    result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                                }
                                            }
                                        // }}SequenceExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes2.AddRange(result.Nodes);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                // }}StarExpression
                                if (result.IsSuccess)
                                {
                                    var nodes4 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes4.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes4.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    // }}SequenceExpression
                    var node3 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next, node3);
                    }
                    else
                    {
                        result = Result.Success(current, current, node3);
                    }
                // }}OptionalExpression
                if (result.IsSuccess)
                {
                    var nodes5 = new List<INode>(10);
                    foreach (var node4 in result.Nodes)
                    {
                        nodes5.AddRange(node4.Children);
                    }
                    result = Result.Success(result, result.Next, nodes5.ToArray());
                }
            // }}LiftExpression
            return __FinishRule(result, "rules");
        }
        
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                // {{NameExpression
                    var result = __Parse(Identifier, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "<=");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{OptionalExpression
                                current = __SkipSpace(current);
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "/");
                                // }}StringLiteralExpression
                                var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next, node);
                                }
                                else
                                {
                                    result = Result.Success(current, current, node);
                                }
                            // }}OptionalExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{NameExpression
                                    result = __Parse(Expression, current);
                                // }}NameExpression
                                if (result.IsSuccess)
                                {
                                    var nodes2 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes2.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes2.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "rule");
        }
        
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = __Parse(Choice, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = __Parse(Sequence, current);
                    // }}NameExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "expression");
        }
        
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{NameExpression
                    var result = __Parse(Sequence, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{PlusExpression
                            var start = current;
                            var nodes2 = new List<INode>(10);
                            for (;;)
                            {
                                // {{SequenceExpression
                                    var nodes3 = new List<INode>(10);
                                    // {{DropExpression
                                        current = __SkipSpace(current);
                                        // {{StringLiteralExpression
                                            result = __MatchString(current, "/");
                                        // }}StringLiteralExpression
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    // }}DropExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes3.AddRange(result.Nodes);
                                        // {{NameExpression
                                            result = __Parse(Sequence, current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes3.AddRange(result.Nodes);
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
                                    }
                                // }}SequenceExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes2.AddRange(result.Nodes);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (nodes2.Count > 0)
                            {
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Plus, nodes2.ToArray());
                                result = Result.Success(location, current, node);
                            }
                            else
                            {
                                result = Result.Fail(start);
                            }
                        // }}PlusExpression
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>(10);
                            foreach (var node2 in result.Nodes)
                            {
                                nodes4.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "choice");
        }
        
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{PlusExpression
                    var start = current;
                    var nodes = new List<INode>(10);
                    IResult result;
                    for (;;)
                    {
                        // {{LiftExpression
                            // {{NameExpression
                                result = __Parse(Prefix, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>(10);
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (nodes.Count > 0)
                    {
                        var location = Location.From(start, current);
                        var node2 = NodeList.From(location, NodeSymbols.Plus, nodes.ToArray());
                        result = Result.Success(location, current, node2);
                    }
                    else
                    {
                        result = Result.Fail(start);
                    }
                // }}PlusExpression
                if (result.IsSuccess)
                {
                    var nodes3 = new List<INode>(10);
                    foreach (var node3 in result.Nodes)
                    {
                        nodes3.AddRange(node3.Children);
                    }
                    result = Result.Success(result, result.Next, nodes3.ToArray());
                }
            // }}LiftExpression
            return __FinishRule(result, "sequence");
        }
        
        // prefix -> Prefix
        public IResult Prefix(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{InlineExpression
                    var result = PrefixAnd(current);
                // }}InlineExpression
                if (!result.IsSuccess)
                {
                    // {{InlineExpression
                        result = PrefixNot(current);
                    // }}InlineExpression
                    if (!result.IsSuccess)
                    {
                        // {{InlineExpression
                            result = PrefixDrop(current);
                        // }}InlineExpression
                        if (!result.IsSuccess)
                        {
                            // {{InlineExpression
                                result = PrefixFuse(current);
                            // }}InlineExpression
                            if (!result.IsSuccess)
                            {
                                // {{InlineExpression
                                    result = PrefixLift(current);
                                // }}InlineExpression
                                if (!result.IsSuccess)
                                {
                                    // {{LiftExpression
                                        // {{NameExpression
                                            result = __Parse(Suffix, current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            var nodes = new List<INode>(10);
                                            foreach (var node in result.Nodes)
                                            {
                                                nodes.AddRange(node.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes.ToArray());
                                        }
                                    // }}LiftExpression
                                }
                            }
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "prefix");
        }
        
        // suffix -> Suffix
        public IResult Suffix(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{InlineExpression
                    var result = SuffixZeroOrOne(current);
                // }}InlineExpression
                if (!result.IsSuccess)
                {
                    // {{InlineExpression
                        result = SuffixZeroOrMore(current);
                    // }}InlineExpression
                    if (!result.IsSuccess)
                    {
                        // {{InlineExpression
                            result = SuffixOneOrMore(current);
                        // }}InlineExpression
                        if (!result.IsSuccess)
                        {
                            // {{LiftExpression
                                // {{NameExpression
                                    result = __Parse(Primary, current);
                                // }}NameExpression
                                if (result.IsSuccess)
                                {
                                    var nodes = new List<INode>(10);
                                    foreach (var node in result.Nodes)
                                    {
                                        nodes.AddRange(node.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes.ToArray());
                                }
                            // }}LiftExpression
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "suffix");
        }
        
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                current = __SkipSpace(current);
                // {{NameExpression
                    var result = __Parse(Identifier, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    current = __SkipSpace(current);
                    // {{NameExpression
                        result = __Parse(VerbatimString, current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        current = __SkipSpace(current);
                        // {{NameExpression
                            result = __Parse(String, current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            current = __SkipSpace(current);
                            // {{NameExpression
                                result = __Parse(CharacterClass, current);
                            // }}NameExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = __Parse(Any, current);
                                // }}NameExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = __Parse(Epsilon, current);
                                    // }}NameExpression
                                    if (!result.IsSuccess)
                                    {
                                        // {{NameExpression
                                            result = __Parse(Inline, current);
                                        // }}NameExpression
                                        if (!result.IsSuccess)
                                        {
                                            // {{SequenceExpression
                                                var nodes = new List<INode>(10);
                                                // {{DropExpression
                                                    current = __SkipSpace(current);
                                                    // {{StringLiteralExpression
                                                        result = __MatchString(current, "(");
                                                    // }}StringLiteralExpression
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                // }}DropExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes.AddRange(result.Nodes);
                                                    // {{LiftExpression
                                                        // {{NameExpression
                                                            result = __Parse(Expression, current);
                                                        // }}NameExpression
                                                        if (result.IsSuccess)
                                                        {
                                                            var nodes2 = new List<INode>(10);
                                                            foreach (var node in result.Nodes)
                                                            {
                                                                nodes2.AddRange(node.Children);
                                                            }
                                                            result = Result.Success(result, result.Next, nodes2.ToArray());
                                                        }
                                                    // }}LiftExpression
                                                    if (result.IsSuccess)
                                                    {
                                                        current = result.Next;
                                                        nodes.AddRange(result.Nodes);
                                                        // {{DropExpression
                                                            current = __SkipSpace(current);
                                                            // {{StringLiteralExpression
                                                                result = __MatchString(current, ")");
                                                            // }}StringLiteralExpression
                                                            if (result.IsSuccess)
                                                            {
                                                                result = Result.Success(result, result.Next);
                                                            }
                                                        // }}DropExpression
                                                        if (result.IsSuccess)
                                                        {
                                                            current = result.Next;
                                                            nodes.AddRange(result.Nodes);
                                                            result = Result.Success(nodes[0], current, nodes.ToArray());
                                                        }
                                                    }
                                                }
                                            // }}SequenceExpression
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "primary");
        }
        
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "(");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Rule, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            current = __SkipSpace(current);
                            // {{StringLiteralExpression
                                result = __MatchString(current, ")");
                            // }}StringLiteralExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "inline");
        }
        
        // any -> Any
        public IResult Any(IContext context)
        {
            var current = context;
            // {{DropExpression
                current = __SkipSpace(current);
                // {{StringLiteralExpression
                    var result = __MatchString(current, ".");
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    result = Result.Success(result, result.Next);
                }
            // }}DropExpression
            return __FinishRule(result, "any");
        }
        
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                current = __SkipSpace(current);
                // {{StringLiteralExpression
                    var result = __MatchString(current, "epsilon");
                // }}StringLiteralExpression
                if (!result.IsSuccess)
                {
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        result = __MatchString(current, "ε");
                    // }}StringLiteralExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "epsilon");
        }
        
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            var current = context;
            // {{NotExpression
                IResult result;
                current = __SkipSpace(current);
                // {{AnyExpression
                    if (!current.AtEnd)
                    {
                        var next = current.Advance(1);
                        var location = Location.From(current, next);
                        var node = Leaf.From(location, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                        result = Result.Success(node, next, node);
                    }
                    else
                    {
                        result = Result.Fail(current);
                    }
                // }}AnyExpression
                if (result.IsSuccess)
                {
                    result = Result.Fail(current);
                }
                else
                {
                    result = Result.Success(result, current);
                }
            // }}NotExpression
            return __FinishRule(result, "eof");
        }
        
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "&");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Suffix, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "prefix.and");
        }
        
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "!");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Suffix, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "prefix.not");
        }
        
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, ",");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Suffix, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "prefix.drop");
        }
        
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "~");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Suffix, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "prefix.fuse");
        }
        
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    current = __SkipSpace(current);
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "^");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(Suffix, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "prefix.lift");
        }
        
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    // {{NameExpression
                        var result = __Parse(Primary, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>(10);
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                // }}LiftExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "?");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "suffix.zero-or-one");
        }
        
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    // {{NameExpression
                        var result = __Parse(Primary, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>(10);
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                // }}LiftExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "*");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "suffix.zero-or-more");
        }
        
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    // {{NameExpression
                        var result = __Parse(Primary, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>(10);
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                // }}LiftExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        current = __SkipSpace(current);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "+");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "suffix.one-or-more");
        }
        
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{FuseExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>(10);
                        // {{NameExpression
                            var result = __Parse(Letter, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes2 = new List<INode>(10);
                                    for (;;)
                                    {
                                        // {{NameExpression
                                            result = __Parse(LetterOrDigit, current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes2.AddRange(result.Nodes);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                // }}StarExpression
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes3.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{LiftExpression
                                    // {{StarExpression
                                        var start2 = current;
                                        var nodes4 = new List<INode>(10);
                                        for (;;)
                                        {
                                            // {{SequenceExpression
                                                var nodes5 = new List<INode>(10);
                                                // {{StringLiteralExpression
                                                    result = __MatchString(current, "-");
                                                // }}StringLiteralExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes5.AddRange(result.Nodes);
                                                    // {{LiftExpression
                                                        // {{PlusExpression
                                                            var start3 = current;
                                                            var nodes6 = new List<INode>(10);
                                                            for (;;)
                                                            {
                                                                // {{NameExpression
                                                                    result = __Parse(LetterOrDigit, current);
                                                                // }}NameExpression
                                                                if (result.IsSuccess)
                                                                {
                                                                    current = result.Next;
                                                                    nodes6.AddRange(result.Nodes);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            if (nodes6.Count > 0)
                                                            {
                                                                var location3 = Location.From(start3, current);
                                                                var node4 = NodeList.From(location3, NodeSymbols.Plus, nodes6.ToArray());
                                                                result = Result.Success(location3, current, node4);
                                                            }
                                                            else
                                                            {
                                                                result = Result.Fail(start3);
                                                            }
                                                        // }}PlusExpression
                                                        if (result.IsSuccess)
                                                        {
                                                            var nodes7 = new List<INode>(10);
                                                            foreach (var node5 in result.Nodes)
                                                            {
                                                                nodes7.AddRange(node5.Children);
                                                            }
                                                            result = Result.Success(result, result.Next, nodes7.ToArray());
                                                        }
                                                    // }}LiftExpression
                                                    if (result.IsSuccess)
                                                    {
                                                        current = result.Next;
                                                        nodes5.AddRange(result.Nodes);
                                                        result = Result.Success(nodes5[0], current, nodes5.ToArray());
                                                    }
                                                }
                                            // }}SequenceExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        var location2 = Location.From(start2, current);
                                        var node3 = NodeList.From(location2, NodeSymbols.Star, nodes4);
                                        result = Result.Success(location2, current, node3);
                                    // }}StarExpression
                                    if (result.IsSuccess)
                                    {
                                        var nodes8 = new List<INode>(10);
                                        foreach (var node6 in result.Nodes)
                                        {
                                            nodes8.AddRange(node6.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes8.ToArray());
                                    }
                                // }}LiftExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    // }}SequenceExpression
                    if (result.IsSuccess)
                    {
                        var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                        var node7 = Leaf.From(result, NodeSymbols.Fusion, value);
                        result = Result.Success(result, result.Next, node7);
                    }
                // }}FuseExpression
                if (!result.IsSuccess)
                {
                    // {{FuseExpression
                        // {{StringLiteralExpression
                            result = __MatchString(current, "_");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            var value2 = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                            var node8 = Leaf.From(result, NodeSymbols.Fusion, value2);
                            result = Result.Success(result, result.Next, node8);
                        }
                    // }}FuseExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "identifier");
        }
        
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "letter");
        }
        
        // letter-or-digit -> LetterOrDigit
        public IResult LetterOrDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "letter-or-digit");
        }
        
        // hex-digit -> HexDigit
        public IResult HexDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','a','b','c','d','e','f'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "hex-digit");
        }
        
        // verbatim-string -> VerbatimString
        public IResult VerbatimString(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    // {{DropExpression
                        // {{StringLiteralExpression
                            var result = __MatchString(current, "\'");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{StarExpression
                                var start = current;
                                var nodes2 = new List<INode>(10);
                                for (;;)
                                {
                                    // {{NameExpression
                                        result = __Parse(VerbatimCharacter, current);
                                    // }}NameExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes2.AddRange(result.Nodes);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            // }}StarExpression
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>(10);
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "\'");
                                // }}StringLiteralExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                // }}SequenceExpression
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node3 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node3);
                }
            // }}FuseExpression
            return __FinishRule(result, "verbatim-string");
        }
        
        // verbatim-character -> VerbatimCharacter
        public IResult VerbatimCharacter(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{NotExpression
                    IResult result;
                    // {{ChoiceExpression
                        // {{StringLiteralExpression
                            result = __MatchString(current, "\'");
                        // }}StringLiteralExpression
                        if (!result.IsSuccess)
                        {
                            // {{StringLiteralExpression
                                result = __MatchString(current, "\\");
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = __Parse(EolChar, current);
                                // }}NameExpression
                            }
                        }
                    // }}ChoiceExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Fail(current);
                    }
                    else
                    {
                        result = Result.Success(result, current);
                    }
                // }}NotExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{AnyExpression
                        if (!current.AtEnd)
                        {
                            var next = current.Advance(1);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                            result = Result.Success(node, next, node);
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    // }}AnyExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "verbatim-character");
        }
        
        // string -> String
        public IResult String(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "\'");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{StarExpression
                            var start = current;
                            var nodes2 = new List<INode>(10);
                            for (;;)
                            {
                                // {{LiftExpression
                                    // {{NameExpression
                                        result = __Parse(Character, current);
                                    // }}NameExpression
                                    if (result.IsSuccess)
                                    {
                                        var nodes3 = new List<INode>(10);
                                        foreach (var node2 in result.Nodes)
                                        {
                                            nodes3.AddRange(node2.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes3.ToArray());
                                    }
                                // }}LiftExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes2.AddRange(result.Nodes);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var location = Location.From(start, current);
                            var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                            result = Result.Success(location, current, node);
                        // }}StarExpression
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>(10);
                            foreach (var node3 in result.Nodes)
                            {
                                nodes4.AddRange(node3.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{StringLiteralExpression
                                result = __MatchString(current, "\'");
                            // }}StringLiteralExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "string");
        }
        
        // character -> Character
        public IResult Character(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = __Parse(StringVerbatim, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = __Parse(Escape, current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        // {{NameExpression
                            result = __Parse(UnicodeEscape, current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = __Parse(ByteEscape, current);
                            // }}NameExpression
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "character");
        }
        
        // string-verbatim -> StringVerbatim
        public IResult StringVerbatim(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    // {{NotExpression
                        IResult result;
                        // {{ChoiceExpression
                            // {{StringLiteralExpression
                                result = __MatchString(current, "\'");
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "\\");
                                // }}StringLiteralExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = __Parse(EolChar, current);
                                    // }}NameExpression
                                }
                            }
                        // }}ChoiceExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Fail(current);
                        }
                        else
                        {
                            result = Result.Success(result, current);
                        }
                    // }}NotExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{AnyExpression
                            if (!current.AtEnd)
                            {
                                var next = current.Advance(1);
                                var location = Location.From(current, next);
                                var node = Leaf.From(location, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                                result = Result.Success(node, next, node);
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        // }}AnyExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                // }}SequenceExpression
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node2 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node2);
                }
            // }}FuseExpression
            return __FinishRule(result, "string-verbatim");
        }
        
        // escape -> Escape
        public IResult Escape(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    // {{DropExpression
                        // {{StringLiteralExpression
                            var result = __MatchString(current, "\\");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{ClassExpression
                            var values = new int[]{'\'','-','0','\\',']','a','b','e','f','n','r','t','v'};
                            result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
                        // }}ClassExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                // }}SequenceExpression
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node);
                }
            // }}FuseExpression
            return __FinishRule(result, "escape");
        }
        
        // unicode-escape -> UnicodeEscape
        public IResult UnicodeEscape(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    // {{SequenceExpression
                        var nodes2 = new List<INode>(10);
                        // {{StringLiteralExpression
                            var result = __MatchString(current, "\\u{");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes2.AddRange(result.Nodes);
                            // {{NameExpression
                                result = __Parse(_, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes2.AddRange(result.Nodes);
                                result = Result.Success(nodes2[0], current, nodes2.ToArray());
                            }
                        }
                    // }}SequenceExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{NameExpression
                        result = __Parse(UnicodeNumber, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{NameExpression
                                result = __Parse(_, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes3 = new List<INode>(10);
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes4 = new List<INode>(10);
                                            // {{NameExpression
                                                result = __Parse(UnicodeNumber, current);
                                            // }}NameExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    // {{NameExpression
                                                        result = __Parse(_, current);
                                                    // }}NameExpression
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                // }}DropExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes4.AddRange(result.Nodes);
                                                    result = Result.Success(nodes4[0], current, nodes4.ToArray());
                                                }
                                            }
                                        // }}SequenceExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes3.AddRange(result.Nodes);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes3);
                                    result = Result.Success(location, current, node);
                                // }}StarExpression
                                if (result.IsSuccess)
                                {
                                    var nodes5 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes5.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes5.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{DropExpression
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "}");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                // }}DropExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "unicode-escape");
        }
        
        // unicode-number -> UnicodeNumber
        public IResult UnicodeNumber(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    // {{NameExpression
                        var result = __Parse(HexDigit, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{OptionalExpression
                                // {{NameExpression
                                    result = __Parse(HexDigit, current);
                                // }}NameExpression
                                var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next, node);
                                }
                                else
                                {
                                    result = Result.Success(current, current, node);
                                }
                            // }}OptionalExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>(10);
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes2.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{OptionalExpression
                                    // {{NameExpression
                                        result = __Parse(HexDigit, current);
                                    // }}NameExpression
                                    var node3 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node3);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node3);
                                    }
                                // }}OptionalExpression
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>(10);
                                    foreach (var node4 in result.Nodes)
                                    {
                                        nodes3.AddRange(node4.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{LiftExpression
                                    // {{OptionalExpression
                                        // {{NameExpression
                                            result = __Parse(HexDigit, current);
                                        // }}NameExpression
                                        var node5 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next, node5);
                                        }
                                        else
                                        {
                                            result = Result.Success(current, current, node5);
                                        }
                                    // }}OptionalExpression
                                    if (result.IsSuccess)
                                    {
                                        var nodes4 = new List<INode>(10);
                                        foreach (var node6 in result.Nodes)
                                        {
                                            nodes4.AddRange(node6.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes4.ToArray());
                                    }
                                // }}LiftExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    // {{LiftExpression
                                        // {{OptionalExpression
                                            // {{NameExpression
                                                result = __Parse(HexDigit, current);
                                            // }}NameExpression
                                            var node7 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                            if (result.IsSuccess)
                                            {
                                                result = Result.Success(result, result.Next, node7);
                                            }
                                            else
                                            {
                                                result = Result.Success(current, current, node7);
                                            }
                                        // }}OptionalExpression
                                        if (result.IsSuccess)
                                        {
                                            var nodes5 = new List<INode>(10);
                                            foreach (var node8 in result.Nodes)
                                            {
                                                nodes5.AddRange(node8.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes5.ToArray());
                                        }
                                    // }}LiftExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes.AddRange(result.Nodes);
                                        // {{LiftExpression
                                            // {{OptionalExpression
                                                // {{NameExpression
                                                    result = __Parse(HexDigit, current);
                                                // }}NameExpression
                                                var node9 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                                if (result.IsSuccess)
                                                {
                                                    result = Result.Success(result, result.Next, node9);
                                                }
                                                else
                                                {
                                                    result = Result.Success(current, current, node9);
                                                }
                                            // }}OptionalExpression
                                            if (result.IsSuccess)
                                            {
                                                var nodes6 = new List<INode>(10);
                                                foreach (var node10 in result.Nodes)
                                                {
                                                    nodes6.AddRange(node10.Children);
                                                }
                                                result = Result.Success(result, result.Next, nodes6.ToArray());
                                            }
                                        // }}LiftExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes.AddRange(result.Nodes);
                                            result = Result.Success(nodes[0], current, nodes.ToArray());
                                        }
                                    }
                                }
                            }
                        }
                    }
                // }}SequenceExpression
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node11 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node11);
                }
            // }}FuseExpression
            return __FinishRule(result, "unicode-number");
        }
        
        // byte-escape -> ByteEscape
        public IResult ByteEscape(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    // {{SequenceExpression
                        var nodes2 = new List<INode>(10);
                        // {{StringLiteralExpression
                            var result = __MatchString(current, "\\x{");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes2.AddRange(result.Nodes);
                            // {{NameExpression
                                result = __Parse(_, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes2.AddRange(result.Nodes);
                                result = Result.Success(nodes2[0], current, nodes2.ToArray());
                            }
                        }
                    // }}SequenceExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{NameExpression
                        result = __Parse(ByteNumber, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{NameExpression
                                result = __Parse(_, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        // }}DropExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes3 = new List<INode>(10);
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes4 = new List<INode>(10);
                                            // {{NameExpression
                                                result = __Parse(ByteNumber, current);
                                            // }}NameExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    // {{NameExpression
                                                        result = __Parse(_, current);
                                                    // }}NameExpression
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                // }}DropExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes4.AddRange(result.Nodes);
                                                    result = Result.Success(nodes4[0], current, nodes4.ToArray());
                                                }
                                            }
                                        // }}SequenceExpression
                                        if (result.IsSuccess)
                                        {
                                            current = result.Next;
                                            nodes3.AddRange(result.Nodes);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes3);
                                    result = Result.Success(location, current, node);
                                // }}StarExpression
                                if (result.IsSuccess)
                                {
                                    var nodes5 = new List<INode>(10);
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes5.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes5.ToArray());
                                }
                            // }}LiftExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                // {{DropExpression
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "}");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                // }}DropExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes.AddRange(result.Nodes);
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "byte-escape");
        }
        
        // byte-number -> ByteNumber
        public IResult ByteNumber(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{NameExpression
                    var result = __Parse(HexDigit, current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{OptionalExpression
                            // {{NameExpression
                                result = __Parse(HexDigit, current);
                            // }}NameExpression
                            var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next, node);
                            }
                            else
                            {
                                result = Result.Success(current, current, node);
                            }
                        // }}OptionalExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>(10);
                            foreach (var node2 in result.Nodes)
                            {
                                nodes2.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    // }}LiftExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "byte-number");
        }
        
        // character-class -> CharacterClass
        public IResult CharacterClass(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{DropExpression
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "[");
                    // }}StringLiteralExpression
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                // }}DropExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{NameExpression
                        result = __Parse(Not, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{StarExpression
                                var start = current;
                                var nodes2 = new List<INode>(10);
                                for (;;)
                                {
                                    // {{LiftExpression
                                        // {{NameExpression
                                            result = __Parse(ClassPart, current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            var nodes3 = new List<INode>(10);
                                            foreach (var node2 in result.Nodes)
                                            {
                                                nodes3.AddRange(node2.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes3.ToArray());
                                        }
                                    // }}LiftExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes2.AddRange(result.Nodes);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            // }}StarExpression
                            if (result.IsSuccess)
                            {
                                var nodes4 = new List<INode>(10);
                                foreach (var node3 in result.Nodes)
                                {
                                    nodes4.AddRange(node3.Children);
                                }
                                result = Result.Success(result, result.Next, nodes4.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "]");
                                // }}StringLiteralExpression
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            // }}DropExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes.AddRange(result.Nodes);
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "character-class");
        }
        
        // not -> Not
        public IResult Not(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{OptionalExpression
                    // {{StringLiteralExpression
                        var result = __MatchString(current, "^");
                    // }}StringLiteralExpression
                    var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next, node);
                    }
                    else
                    {
                        result = Result.Success(current, current, node);
                    }
                // }}OptionalExpression
                if (result.IsSuccess)
                {
                    var nodes = new List<INode>(10);
                    foreach (var node2 in result.Nodes)
                    {
                        nodes.AddRange(node2.Children);
                    }
                    result = Result.Success(result, result.Next, nodes.ToArray());
                }
            // }}LiftExpression
            return __FinishRule(result, "not");
        }
        
        // class-part -> ClassPart
        public IResult ClassPart(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = __Parse(Range, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{LiftExpression
                        // {{NameExpression
                            result = __Parse(ClassChar, current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes = new List<INode>(10);
                            foreach (var node in result.Nodes)
                            {
                                nodes.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes.ToArray());
                        }
                    // }}LiftExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "class-part");
        }
        
        // range -> Range
        public IResult Range(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    // {{NameExpression
                        var result = __Parse(ClassChar, current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>(10);
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                // }}LiftExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        // {{StringLiteralExpression
                            result = __MatchString(current, "-");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    // }}DropExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{NameExpression
                                result = __Parse(ClassChar, current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>(10);
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        // }}LiftExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "range");
        }
        
        // class-char -> ClassChar
        public IResult ClassChar(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = __Parse(ClassVerbatim, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = __Parse(Escape, current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        // {{NameExpression
                            result = __Parse(UnicodeEscape, current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = __Parse(ByteEscape, current);
                            // }}NameExpression
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "class-char");
        }
        
        // class-verbatim -> ClassVerbatim
        public IResult ClassVerbatim(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    // {{NotExpression
                        IResult result;
                        // {{ChoiceExpression
                            // {{StringLiteralExpression
                                result = __MatchString(current, "]");
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{StringLiteralExpression
                                    result = __MatchString(current, "\\");
                                // }}StringLiteralExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = __Parse(EolChar, current);
                                    // }}NameExpression
                                }
                            }
                        // }}ChoiceExpression
                        if (result.IsSuccess)
                        {
                            result = Result.Fail(current);
                        }
                        else
                        {
                            result = Result.Success(result, current);
                        }
                    // }}NotExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{AnyExpression
                            if (!current.AtEnd)
                            {
                                var next = current.Advance(1);
                                var location = Location.From(current, next);
                                var node = Leaf.From(location, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                                result = Result.Success(node, next, node);
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        // }}AnyExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                // }}SequenceExpression
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node2 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node2);
                }
            // }}FuseExpression
            return __FinishRule(result, "class-verbatim");
        }
        
        // _ -> _
        public IResult _(IContext context)
        {
            var current = context;
            // {{StarExpression
                var start = current;
                var nodes = new List<INode>(10);
                IResult result;
                for (;;)
                {
                    // {{ChoiceExpression
                        // {{NameExpression
                            result = __Parse(Whitespace, current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = __Parse(Newline, current);
                            // }}NameExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = __Parse(Comment, current);
                                // }}NameExpression
                            }
                        }
                    // }}ChoiceExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                    }
                    else
                    {
                        break;
                    }
                }
                var location = Location.From(start, current);
                var node = NodeList.From(location, NodeSymbols.Star, nodes);
                result = Result.Success(location, current, node);
            // }}StarExpression
            return __FinishRule(result, "_");
        }
        
        // comment -> Comment
        public IResult Comment(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = __Parse(SingleLineComment, current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = __Parse(MultiLineComment, current);
                    // }}NameExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "comment");
        }
        
        // single-line-comment -> SingleLineComment
        public IResult SingleLineComment(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{StringLiteralExpression
                    var result = __MatchString(current, "//");
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{StarExpression
                        var start = current;
                        var nodes2 = new List<INode>(10);
                        for (;;)
                        {
                            // {{SequenceExpression
                                var nodes3 = new List<INode>(10);
                                // {{NotExpression
                                    // {{NameExpression
                                        result = __Parse(EolChar, current);
                                    // }}NameExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Fail(current);
                                    }
                                    else
                                    {
                                        result = Result.Success(result, current);
                                    }
                                // }}NotExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes3.AddRange(result.Nodes);
                                    // {{AnyExpression
                                        if (!current.AtEnd)
                                        {
                                            var next = current.Advance(1);
                                            var location2 = Location.From(current, next);
                                            var node2 = Leaf.From(location2, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                                            result = Result.Success(node2, next, node2);
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    // }}AnyExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes3.AddRange(result.Nodes);
                                        result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                    }
                                }
                            // }}SequenceExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes2.AddRange(result.Nodes);
                            }
                            else
                            {
                                break;
                            }
                        }
                        var location = Location.From(start, current);
                        var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                        result = Result.Success(location, current, node);
                    // }}StarExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "single-line-comment");
        }
        
        // multi-line-comment -> MultiLineComment
        public IResult MultiLineComment(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{StringLiteralExpression
                    var result = __MatchString(current, "/*");
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{StarExpression
                        var start = current;
                        var nodes2 = new List<INode>(10);
                        for (;;)
                        {
                            // {{SequenceExpression
                                var nodes3 = new List<INode>(10);
                                // {{NotExpression
                                    // {{StringLiteralExpression
                                        result = __MatchString(current, "*/");
                                    // }}StringLiteralExpression
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Fail(current);
                                    }
                                    else
                                    {
                                        result = Result.Success(result, current);
                                    }
                                // }}NotExpression
                                if (result.IsSuccess)
                                {
                                    current = result.Next;
                                    nodes3.AddRange(result.Nodes);
                                    // {{AnyExpression
                                        if (!current.AtEnd)
                                        {
                                            var next = current.Advance(1);
                                            var location2 = Location.From(current, next);
                                            var node2 = Leaf.From(location2, NodeSymbols.Any, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                                            result = Result.Success(node2, next, node2);
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    // }}AnyExpression
                                    if (result.IsSuccess)
                                    {
                                        current = result.Next;
                                        nodes3.AddRange(result.Nodes);
                                        result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                    }
                                }
                            // }}SequenceExpression
                            if (result.IsSuccess)
                            {
                                current = result.Next;
                                nodes2.AddRange(result.Nodes);
                            }
                            else
                            {
                                break;
                            }
                        }
                        var location = Location.From(start, current);
                        var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                        result = Result.Success(location, current, node);
                    // }}StarExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{StringLiteralExpression
                            result = __MatchString(current, "*/");
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            // }}SequenceExpression
            return __FinishRule(result, "multi-line-comment");
        }
        
        // newline -> Newline
        public IResult Newline(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{StringLiteralExpression
                    var result = __MatchString(current, "\r\n");
                // }}StringLiteralExpression
                if (!result.IsSuccess)
                {
                    // {{ClassExpression
                        var values = new int[]{'\n','\r',0x2028,0x2029};
                        result = __MatchPredicate(current, _current => Array.IndexOf(values, _current) >= 0);
                    // }}ClassExpression
                }
            // }}ChoiceExpression
            return __FinishRule(result, "newline");
        }
        
        // eol-char -> EolChar
        public IResult EolChar(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'\n','\r',0x2028,0x2029};
                var result = __MatchPredicate(current, _current => Array.IndexOf(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "eol-char");
        }
        
        // whitespace -> Whitespace
        public IResult Whitespace(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'\t','\v','\f',' ',0xA0,0x1680,0x180E,0x2000,0x2001,0x2002,0x2003,0x2004,0x2005,0x2006,0x2007,0x2008,0x2009,0x200A,0x202F,0x205F,0x3000,0xFEFF};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "whitespace");
        }
    }
}
