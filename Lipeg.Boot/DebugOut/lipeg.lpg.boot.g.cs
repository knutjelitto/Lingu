namespace Lipeg.Command
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Lipeg.Runtime;
    
    public partial class LipegParser : ParserBase
    {
        public override IResult Parse(IContext context)
        {
            __ClearCache();
            return Start(context);
        }
        
        public override IContext __SkipSpace(IContext context)
        {
            return _(context).Next;
        }
        
        // start -> Start
        protected virtual IResult Start(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                var result = __Parse(Grammar, current);
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    result = __Parse(Eof, current);
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
        protected virtual IResult Grammar(IContext context)
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
                    result = __Parse(Identifier, current);
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
                                            result = __Parse(Options, current);
                                            if (!result.IsSuccess)
                                            {
                                                result = __Parse(Syntax, current);
                                                if (!result.IsSuccess)
                                                {
                                                    result = __Parse(Lexical, current);
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
        protected virtual IResult Options(IContext context)
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
                                    result = __Parse(Option, current);
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
        protected virtual IResult Option(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                var result = __Parse(Identifier, current);
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
                        result = __Parse(OptionValue, current);
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
        protected virtual IResult OptionValue(IContext context)
        {
            var current = context;
            var result = __Parse(QualifiedIdentifier, current);
            return __FinishRule(result, "option-value");
        }
        
        // qualified-identifier -> QualifiedIdentifier
        protected virtual IResult QualifiedIdentifier(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                var result = __Parse(Identifier, current);
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
                                        result = __Parse(Identifier, current);
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
        protected virtual IResult Syntax(IContext context)
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
                            result = __Parse(Rules, current);
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
        protected virtual IResult Lexical(IContext context)
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
                            result = __Parse(Rules, current);
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
        protected virtual IResult Rules(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{OptionalExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>(10);
                        var result = __Parse(Rule, current);
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
                                                result = __Parse(Rule, current);
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
        protected virtual IResult Rule(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                current = __SkipSpace(current);
                var result = __Parse(Identifier, current);
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
                                result = __Parse(Expression, current);
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
        protected virtual IResult Expression(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                var result = __Parse(Choice, current);
                if (!result.IsSuccess)
                {
                    result = __Parse(Sequence, current);
                }
            // }}ChoiceExpression
            return __FinishRule(result, "expression");
        }
        
        // choice -> Choice
        protected virtual IResult Choice(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                var result = __Parse(Sequence, current);
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
                                        result = __Parse(Sequence, current);
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
        protected virtual IResult Sequence(IContext context)
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
                            result = __Parse(Prefix, current);
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
        protected virtual IResult Prefix(IContext context)
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
                                        result = __Parse(Suffix, current);
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
        protected virtual IResult Suffix(IContext context)
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
                                result = __Parse(Primary, current);
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
        protected virtual IResult Primary(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                current = __SkipSpace(current);
                var result = __Parse(Identifier, current);
                if (!result.IsSuccess)
                {
                    current = __SkipSpace(current);
                    result = __Parse(VerbatimString, current);
                    if (!result.IsSuccess)
                    {
                        current = __SkipSpace(current);
                        result = __Parse(String, current);
                        if (!result.IsSuccess)
                        {
                            current = __SkipSpace(current);
                            result = __Parse(CharacterClass, current);
                            if (!result.IsSuccess)
                            {
                                result = __Parse(Any, current);
                                if (!result.IsSuccess)
                                {
                                    result = __Parse(Epsilon, current);
                                    if (!result.IsSuccess)
                                    {
                                        result = __Parse(Inline, current);
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
                                                        result = __Parse(Expression, current);
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
        protected virtual IResult Inline(IContext context)
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
                        result = __Parse(Rule, current);
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
        protected virtual IResult Any(IContext context)
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
        protected virtual IResult Epsilon(IContext context)
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
        protected virtual IResult Eof(IContext context)
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
        protected virtual IResult PrefixAnd(IContext context)
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
                        result = __Parse(Suffix, current);
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
        protected virtual IResult PrefixNot(IContext context)
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
                        result = __Parse(Suffix, current);
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
        protected virtual IResult PrefixDrop(IContext context)
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
                        result = __Parse(Suffix, current);
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
        protected virtual IResult PrefixFuse(IContext context)
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
                        result = __Parse(Suffix, current);
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
        protected virtual IResult PrefixLift(IContext context)
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
                        result = __Parse(Suffix, current);
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
        protected virtual IResult SuffixZeroOrOne(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    var result = __Parse(Primary, current);
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
        protected virtual IResult SuffixZeroOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    var result = __Parse(Primary, current);
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
        protected virtual IResult SuffixOneOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    var result = __Parse(Primary, current);
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
        protected virtual IResult Identifier(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{FuseExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>(10);
                        var result = __Parse(Letter, current);
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
                                        result = __Parse(LetterOrDigit, current);
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
                                                                result = __Parse(LetterOrDigit, current);
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
        protected virtual IResult Letter(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "letter");
        }
        
        // letter-or-digit -> LetterOrDigit
        protected virtual IResult LetterOrDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "letter-or-digit");
        }
        
        // hex-digit -> HexDigit
        protected virtual IResult HexDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','a','b','c','d','e','f'};
                var result = __MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "hex-digit");
        }
        
        // verbatim-string -> VerbatimString
        protected virtual IResult VerbatimString(IContext context)
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
                                    result = __Parse(VerbatimCharacter, current);
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
        protected virtual IResult VerbatimCharacter(IContext context)
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
                                result = __Parse(EolChar, current);
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
        protected virtual IResult String(IContext context)
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
                                    result = __Parse(Character, current);
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
        protected virtual IResult Character(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                var result = __Parse(StringVerbatim, current);
                if (!result.IsSuccess)
                {
                    result = __Parse(Escape, current);
                    if (!result.IsSuccess)
                    {
                        result = __Parse(UnicodeEscape, current);
                        if (!result.IsSuccess)
                        {
                            result = __Parse(ByteEscape, current);
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "character");
        }
        
        // string-verbatim -> StringVerbatim
        protected virtual IResult StringVerbatim(IContext context)
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
                                    result = __Parse(EolChar, current);
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
        protected virtual IResult Escape(IContext context)
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
        protected virtual IResult UnicodeEscape(IContext context)
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
                            result = __Parse(_, current);
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
                    result = __Parse(UnicodeNumber, current);
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            result = __Parse(_, current);
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
                                            result = __Parse(UnicodeNumber, current);
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    result = __Parse(_, current);
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
        protected virtual IResult UnicodeNumber(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>(10);
                    var result = __Parse(HexDigit, current);
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{OptionalExpression
                                result = __Parse(HexDigit, current);
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
                                    result = __Parse(HexDigit, current);
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
                                        result = __Parse(HexDigit, current);
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
                                            result = __Parse(HexDigit, current);
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
                                                result = __Parse(HexDigit, current);
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
        protected virtual IResult ByteEscape(IContext context)
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
                            result = __Parse(_, current);
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
                    result = __Parse(ByteNumber, current);
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            result = __Parse(_, current);
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
                                            result = __Parse(ByteNumber, current);
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    result = __Parse(_, current);
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
        protected virtual IResult ByteNumber(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                var result = __Parse(HexDigit, current);
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{OptionalExpression
                            result = __Parse(HexDigit, current);
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
        protected virtual IResult CharacterClass(IContext context)
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
                    result = __Parse(Not, current);
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
                                        result = __Parse(ClassPart, current);
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
        protected virtual IResult Not(IContext context)
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
        protected virtual IResult ClassPart(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                var result = __Parse(Range, current);
                if (!result.IsSuccess)
                {
                    // {{LiftExpression
                        result = __Parse(ClassChar, current);
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
        protected virtual IResult Range(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>(10);
                // {{LiftExpression
                    var result = __Parse(ClassChar, current);
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
                            result = __Parse(ClassChar, current);
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
        protected virtual IResult ClassChar(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                var result = __Parse(ClassVerbatim, current);
                if (!result.IsSuccess)
                {
                    result = __Parse(Escape, current);
                    if (!result.IsSuccess)
                    {
                        result = __Parse(UnicodeEscape, current);
                        if (!result.IsSuccess)
                        {
                            result = __Parse(ByteEscape, current);
                        }
                    }
                }
            // }}ChoiceExpression
            return __FinishRule(result, "class-char");
        }
        
        // class-verbatim -> ClassVerbatim
        protected virtual IResult ClassVerbatim(IContext context)
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
                                    result = __Parse(EolChar, current);
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
        protected virtual IResult _(IContext context)
        {
            var current = context;
            // {{StarExpression
                var start = current;
                var nodes = new List<INode>(10);
                IResult result;
                for (;;)
                {
                    // {{ChoiceExpression
                        result = __Parse(Whitespace, current);
                        if (!result.IsSuccess)
                        {
                            result = __Parse(Newline, current);
                            if (!result.IsSuccess)
                            {
                                result = __Parse(Comment, current);
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
        protected virtual IResult Comment(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                var result = __Parse(SingleLineComment, current);
                if (!result.IsSuccess)
                {
                    result = __Parse(MultiLineComment, current);
                }
            // }}ChoiceExpression
            return __FinishRule(result, "comment");
        }
        
        // single-line-comment -> SingleLineComment
        protected virtual IResult SingleLineComment(IContext context)
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
                                    result = __Parse(EolChar, current);
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
        protected virtual IResult MultiLineComment(IContext context)
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
        protected virtual IResult Newline(IContext context)
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
        protected virtual IResult EolChar(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new int[]{'\n','\r',0x2028,0x2029};
                var result = __MatchPredicate(current, _current => Array.IndexOf(values, _current) >= 0);
            // }}ClassExpression
            return __FinishRule(result, "eol-char");
        }
        
        // whitespace -> Whitespace
        protected virtual IResult Whitespace(IContext context)
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
