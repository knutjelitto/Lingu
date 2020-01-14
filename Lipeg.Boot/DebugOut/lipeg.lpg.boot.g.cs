namespace Lipeg.Command
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Lipeg.SDK.Tree;
    using Lipeg.Runtime;
    
    public partial class LipegParser : ParserBase
    {
        // start -> Start
        public IResult Start(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                var result = Grammar(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    result = Eof(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(5);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "grammar";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    result = Identifier(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            // SHOULD SPACE <_>
                            current = _(current).Next;
                            // StringLiteralExpression:
                            var str2 = "{";
                            result = this.MatchString(current, str2);
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // StarExpression:
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // ChoiceExpression:
                                            result = Options(current);
                                            if (!result.IsSuccess)
                                            {
                                                result = Syntax(current);
                                                if (!result.IsSuccess)
                                                {
                                                    result = Lexical(current);
                                                }
                                            }
                                        if (result.IsSuccess)
                                        {
                                            nodes2.AddRange(result.Nodes);
                                            current = result.Next;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes3.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                    // SHOULD SPACE <_>
                                    current = _(current).Next;
                                    // StringLiteralExpression:
                                    var str3 = "}";
                                    result = this.MatchString(current, str3);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // options -> Options
        public IResult Options(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(4);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "options";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str2 = "{";
                        result = this.MatchString(current, str2);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            // StarExpression:
                                var start = current;
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    result = Option(current);
                                    if (result.IsSuccess)
                                    {
                                        nodes2.AddRange(result.Nodes);
                                        current = result.Next;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>();
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // SHOULD SPACE <_>
                                current = _(current).Next;
                                // StringLiteralExpression:
                                var str3 = "}";
                                result = this.MatchString(current, str3);
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            return result;
        }
        
        // option -> Option
        public IResult Option(IContext context)
        {
            var current = context;
            // SHOULD SPACE <_>
            current = _(current).Next;
            // SequenceExpression:
                var nodes = new List<INode>(4);
                // SHOULD SPACE <_>
                current = _(current).Next;
                var result = Identifier(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str = "=";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = OptionValue(current);
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // SHOULD SPACE <_>
                                current = _(current).Next;
                                // StringLiteralExpression:
                                var str2 = ";";
                                result = this.MatchString(current, str2);
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            return result;
        }
        
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            var current = context;
            var result = QualifiedIdentifier(current);
            return result;
        }
        
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            var current = context;
            // SHOULD SPACE <_>
            current = _(current).Next;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // SHOULD SPACE <_>
                current = _(current).Next;
                var result = Identifier(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        // StarExpression:
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // SequenceExpression:
                                    var nodes3 = new List<INode>(2);
                                    // DropExpression:
                                        // SHOULD SPACE <_>
                                        current = _(current).Next;
                                        // StringLiteralExpression:
                                        var str = ".";
                                        result = this.MatchString(current, str);
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        // SHOULD SPACE <_>
                                        current = _(current).Next;
                                        result = Identifier(current);
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes2.AddRange(result.Nodes);
                                    current = result.Next;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var location = Location.From(start, current);
                            var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                            result = Result.Success(location, current, node);
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>();
                            foreach (var node2 in result.Nodes)
                            {
                                nodes4.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(5);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "syntax";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str2 = "{";
                        result = this.MatchString(current, str2);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            result = Rules(current);
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // SHOULD SPACE <_>
                                current = _(current).Next;
                                // OptionalExpression:
                                {
                                    // SHOULD SPACE <_>
                                    current = _(current).Next;
                                    // StringLiteralExpression:
                                    var str3 = ";";
                                    result = this.MatchString(current, str3);
                                    var node2 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node2);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node2);
                                    }
                                }
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                    // SHOULD SPACE <_>
                                    current = _(current).Next;
                                    // StringLiteralExpression:
                                    var str4 = "}";
                                    result = this.MatchString(current, str4);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(5);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "lexical";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str2 = "{";
                        result = this.MatchString(current, str2);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            result = Rules(current);
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // SHOULD SPACE <_>
                                current = _(current).Next;
                                // OptionalExpression:
                                {
                                    // SHOULD SPACE <_>
                                    current = _(current).Next;
                                    // StringLiteralExpression:
                                    var str3 = ";";
                                    result = this.MatchString(current, str3);
                                    var node2 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node2);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node2);
                                    }
                                }
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                    // SHOULD SPACE <_>
                                    current = _(current).Next;
                                    // StringLiteralExpression:
                                    var str4 = "}";
                                    result = this.MatchString(current, str4);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            var current = context;
            // LiftExpression:
                IResult result;
                // OptionalExpression:
                {
                    // SequenceExpression:
                        var nodes = new List<INode>(2);
                        result = Rule(current);
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // StarExpression:
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // SequenceExpression:
                                            var nodes3 = new List<INode>(2);
                                            // DropExpression:
                                                // SHOULD SPACE <_>
                                                current = _(current).Next;
                                                // StringLiteralExpression:
                                                var str = ";";
                                                result = this.MatchString(current, str);
                                                if (result.IsSuccess)
                                                {
                                                    result = Result.Success(result, result.Next);
                                                }
                                            if (result.IsSuccess)
                                            {
                                                nodes3.AddRange(result.Nodes);
                                                current = result.Next;
                                                result = Rule(current);
                                                if (result.IsSuccess)
                                                {
                                                    nodes3.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                                }
                                            }
                                        if (result.IsSuccess)
                                        {
                                            nodes2.AddRange(result.Nodes);
                                            current = result.Next;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                if (result.IsSuccess)
                                {
                                    var nodes4 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes4.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes4.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    var node3 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next, node3);
                    }
                    else
                    {
                        result = Result.Success(current, current, node3);
                    }
                }
                if (result.IsSuccess)
                {
                    var nodes5 = new List<INode>();
                    foreach (var node4 in result.Nodes)
                    {
                        nodes5.AddRange(node4.Children);
                    }
                    result = Result.Success(result, result.Next, nodes5.ToArray());
                }
            return result;
        }
        
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            var current = context;
            // SHOULD SPACE <_>
            current = _(current).Next;
            // SequenceExpression:
                var nodes = new List<INode>(4);
                // SHOULD SPACE <_>
                current = _(current).Next;
                var result = Identifier(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str = "<=";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            // SHOULD SPACE <_>
                            current = _(current).Next;
                            // OptionalExpression:
                            {
                                // SHOULD SPACE <_>
                                current = _(current).Next;
                                // StringLiteralExpression:
                                var str2 = "/";
                                result = this.MatchString(current, str2);
                                var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next, node);
                                }
                                else
                                {
                                    result = Result.Success(current, current, node);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                result = Expression(current);
                                if (result.IsSuccess)
                                {
                                    var nodes2 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes2.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes2.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            return result;
        }
        
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                var result = Choice(current);
                if (!result.IsSuccess)
                {
                    result = Sequence(current);
                }
            return result;
        }
        
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                var result = Sequence(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        // PlusExpression:
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // SequenceExpression:
                                    var nodes3 = new List<INode>(2);
                                    // DropExpression:
                                        // SHOULD SPACE <_>
                                        current = _(current).Next;
                                        // StringLiteralExpression:
                                        var str = "/";
                                        result = this.MatchString(current, str);
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        result = Sequence(current);
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes2.AddRange(result.Nodes);
                                    current = result.Next;
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
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>();
                            foreach (var node2 in result.Nodes)
                            {
                                nodes4.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            var current = context;
            // LiftExpression:
                IResult result;
                // PlusExpression:
                    var start = current;
                    var nodes = new List<INode>();
                    for (;;)
                    {
                        // LiftExpression:
                            result = Prefix(current);
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
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
                if (result.IsSuccess)
                {
                    var nodes3 = new List<INode>();
                    foreach (var node3 in result.Nodes)
                    {
                        nodes3.AddRange(node3.Children);
                    }
                    result = Result.Success(result, result.Next, nodes3.ToArray());
                }
            return result;
        }
        
        // prefix -> Prefix
        public IResult Prefix(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                IResult result;
                // InlineExpression:
                {
                    // prefix.and
                    result = PrefixAnd(current);
                }
                if (!result.IsSuccess)
                {
                    // InlineExpression:
                    {
                        // prefix.not
                        result = PrefixNot(current);
                    }
                    if (!result.IsSuccess)
                    {
                        // InlineExpression:
                        {
                            // prefix.drop
                            result = PrefixDrop(current);
                        }
                        if (!result.IsSuccess)
                        {
                            // InlineExpression:
                            {
                                // prefix.fuse
                                result = PrefixFuse(current);
                            }
                            if (!result.IsSuccess)
                            {
                                // InlineExpression:
                                {
                                    // prefix.lift
                                    result = PrefixLift(current);
                                }
                                if (!result.IsSuccess)
                                {
                                    // LiftExpression:
                                        result = Suffix(current);
                                        if (result.IsSuccess)
                                        {
                                            var nodes = new List<INode>();
                                            foreach (var node in result.Nodes)
                                            {
                                                nodes.AddRange(node.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes.ToArray());
                                        }
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // suffix -> Suffix
        public IResult Suffix(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                IResult result;
                // InlineExpression:
                {
                    // suffix.zero-or-one
                    result = SuffixZeroOrOne(current);
                }
                if (!result.IsSuccess)
                {
                    // InlineExpression:
                    {
                        // suffix.zero-or-more
                        result = SuffixZeroOrMore(current);
                    }
                    if (!result.IsSuccess)
                    {
                        // InlineExpression:
                        {
                            // suffix.one-or-more
                            result = SuffixOneOrMore(current);
                        }
                        if (!result.IsSuccess)
                        {
                            // LiftExpression:
                                result = Primary(current);
                                if (result.IsSuccess)
                                {
                                    var nodes = new List<INode>();
                                    foreach (var node in result.Nodes)
                                    {
                                        nodes.AddRange(node.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes.ToArray());
                                }
                        }
                    }
                }
            return result;
        }
        
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                // SHOULD SPACE <_>
                current = _(current).Next;
                var result = Identifier(current);
                if (!result.IsSuccess)
                {
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    result = VerbatimString(current);
                    if (!result.IsSuccess)
                    {
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        result = String(current);
                        if (!result.IsSuccess)
                        {
                            // SHOULD SPACE <_>
                            current = _(current).Next;
                            result = CharacterClass(current);
                            if (!result.IsSuccess)
                            {
                                result = Any(current);
                                if (!result.IsSuccess)
                                {
                                    result = Epsilon(current);
                                    if (!result.IsSuccess)
                                    {
                                        result = Inline(current);
                                        if (!result.IsSuccess)
                                        {
                                            // SequenceExpression:
                                                var nodes = new List<INode>(3);
                                                // DropExpression:
                                                    // SHOULD SPACE <_>
                                                    current = _(current).Next;
                                                    // StringLiteralExpression:
                                                    var str = "(";
                                                    result = this.MatchString(current, str);
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                if (result.IsSuccess)
                                                {
                                                    nodes.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    // LiftExpression:
                                                        result = Expression(current);
                                                        if (result.IsSuccess)
                                                        {
                                                            var nodes2 = new List<INode>();
                                                            foreach (var node in result.Nodes)
                                                            {
                                                                nodes2.AddRange(node.Children);
                                                            }
                                                            result = Result.Success(result, result.Next, nodes2.ToArray());
                                                        }
                                                    if (result.IsSuccess)
                                                    {
                                                        nodes.AddRange(result.Nodes);
                                                        current = result.Next;
                                                        // DropExpression:
                                                            // SHOULD SPACE <_>
                                                            current = _(current).Next;
                                                            // StringLiteralExpression:
                                                            var str2 = ")";
                                                            result = this.MatchString(current, str2);
                                                            if (result.IsSuccess)
                                                            {
                                                                result = Result.Success(result, result.Next);
                                                            }
                                                        if (result.IsSuccess)
                                                        {
                                                            nodes.AddRange(result.Nodes);
                                                            current = result.Next;
                                                            result = Result.Success(nodes[0], current, nodes.ToArray());
                                                        }
                                                    }
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(3);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "(";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Rule(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            // SHOULD SPACE <_>
                            current = _(current).Next;
                            // StringLiteralExpression:
                            var str2 = ")";
                            result = this.MatchString(current, str2);
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            return result;
        }
        
        // any -> Any
        public IResult Any(IContext context)
        {
            var current = context;
            // DropExpression:
                // SHOULD SPACE <_>
                current = _(current).Next;
                // StringLiteralExpression:
                var str = ".";
                var result = this.MatchString(current, str);
                if (result.IsSuccess)
                {
                    result = Result.Success(result, result.Next);
                }
            return result;
        }
        
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            var current = context;
            // SHOULD SPACE <_>
            current = _(current).Next;
            // ChoiceExpression:
                // SHOULD SPACE <_>
                current = _(current).Next;
                // StringLiteralExpression:
                var str = "epsilon";
                var result = this.MatchString(current, str);
                if (!result.IsSuccess)
                {
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str2 = "ε";
                    result = this.MatchString(current, str2);
                }
            return result;
        }
        
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            var current = context;
            // SHOULD SPACE <_>
            current = _(current).Next;
            IResult result;
            // NotExpression:
                // SHOULD SPACE <_>
                current = _(current).Next;
                // VisitAnyExpression:
                {
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
                }
                if (result.IsSuccess)
                {
                    result = Result.Fail(current);
                }
                else
                {
                    result = Result.Success(result, current);
                }
            return result;
        }
        
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "&";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Suffix(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "!";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Suffix(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = ",";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Suffix(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "~";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Suffix(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // DropExpression:
                    // SHOULD SPACE <_>
                    current = _(current).Next;
                    // StringLiteralExpression:
                    var str = "^";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        result = Suffix(current);
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes2.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // LiftExpression:
                    var result = Primary(current);
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str = "?";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // LiftExpression:
                    var result = Primary(current);
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str = "*";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // LiftExpression:
                    var result = Primary(current);
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // SHOULD SPACE <_>
                        current = _(current).Next;
                        // StringLiteralExpression:
                        var str = "+";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                IResult result;
                // FuseExpression:
                {
                    // SequenceExpression:
                        var nodes = new List<INode>(3);
                        result = Letter(current);
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // StarExpression:
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        result = LetterOrDigit(current);
                                        if (result.IsSuccess)
                                        {
                                            nodes2.AddRange(result.Nodes);
                                            current = result.Next;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location, current, node);
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes3.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // LiftExpression:
                                    // StarExpression:
                                        var start2 = current;
                                        var nodes4 = new List<INode>();
                                        for (;;)
                                        {
                                            // SequenceExpression:
                                                var nodes5 = new List<INode>(2);
                                                // StringLiteralExpression:
                                                var str = "-";
                                                result = this.MatchString(current, str);
                                                if (result.IsSuccess)
                                                {
                                                    nodes5.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    // LiftExpression:
                                                        // PlusExpression:
                                                            var start3 = current;
                                                            var nodes6 = new List<INode>();
                                                            for (;;)
                                                            {
                                                                result = LetterOrDigit(current);
                                                                if (result.IsSuccess)
                                                                {
                                                                    nodes6.AddRange(result.Nodes);
                                                                    current = result.Next;
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
                                                        if (result.IsSuccess)
                                                        {
                                                            var nodes7 = new List<INode>();
                                                            foreach (var node5 in result.Nodes)
                                                            {
                                                                nodes7.AddRange(node5.Children);
                                                            }
                                                            result = Result.Success(result, result.Next, nodes7.ToArray());
                                                        }
                                                    if (result.IsSuccess)
                                                    {
                                                        nodes5.AddRange(result.Nodes);
                                                        current = result.Next;
                                                        result = Result.Success(nodes5[0], current, nodes5.ToArray());
                                                    }
                                                }
                                            if (result.IsSuccess)
                                            {
                                                nodes4.AddRange(result.Nodes);
                                                current = result.Next;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        var location2 = Location.From(start2, current);
                                        var node3 = NodeList.From(location2, NodeSymbols.Star, nodes4);
                                        result = Result.Success(location2, current, node3);
                                    if (result.IsSuccess)
                                    {
                                        var nodes8 = new List<INode>();
                                        foreach (var node6 in result.Nodes)
                                        {
                                            nodes8.AddRange(node6.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes8.ToArray());
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    if (result.IsSuccess)
                    {
                        var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                        var node7 = Leaf.From(result, NodeSymbols.Fusion, value);
                        result = Result.Success(result, result.Next, node7);
                    }
                }
                if (!result.IsSuccess)
                {
                    // FuseExpression:
                    {
                        // StringLiteralExpression:
                        var str2 = "_";
                        result = this.MatchString(current, str2);
                        if (result.IsSuccess)
                        {
                            var value2 = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                            var node8 = Leaf.From(result, NodeSymbols.Fusion, value2);
                            result = Result.Success(result, result.Next, node8);
                        }
                    }
                }
            return result;
        }
        
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            var current = context;
            // ClassExpression
            var values = new []{65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122};
            var result = this.MatchPredicate(current, (cur) => Array.BinarySearch(values, cur) >= 0);
            return result;
        }
        
        // letter-or-digit -> LetterOrDigit
        public IResult LetterOrDigit(IContext context)
        {
            var current = context;
            // ClassExpression
            var values = new []{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122};
            var result = this.MatchPredicate(current, (cur) => Array.BinarySearch(values, cur) >= 0);
            return result;
        }
        
        // hex-digit -> HexDigit
        public IResult HexDigit(IContext context)
        {
            var current = context;
            // ClassExpression
            var values = new []{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70,97,98,99,100,101,102};
            var result = this.MatchPredicate(current, (cur) => Array.BinarySearch(values, cur) >= 0);
            return result;
        }
        
        // verbatim-string -> VerbatimString
        public IResult VerbatimString(IContext context)
        {
            var current = context;
            IResult result;
            // FuseExpression:
            {
                // SequenceExpression:
                    var nodes = new List<INode>(3);
                    // DropExpression:
                        // StringLiteralExpression:
                        var str = "\'";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            // StarExpression:
                                var start = current;
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    result = VerbatimCharacter(current);
                                    if (result.IsSuccess)
                                    {
                                        nodes2.AddRange(result.Nodes);
                                        current = result.Next;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>();
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // StringLiteralExpression:
                                var str2 = "\'";
                                result = this.MatchString(current, str2);
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node3 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node3);
                }
            }
            return result;
        }
        
        // verbatim-character -> VerbatimCharacter
        public IResult VerbatimCharacter(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                IResult result;
                // NotExpression:
                    // ChoiceExpression:
                        // StringLiteralExpression:
                        var str = "\'";
                        result = this.MatchString(current, str);
                        if (!result.IsSuccess)
                        {
                            // StringLiteralExpression:
                            var str2 = "\\";
                            result = this.MatchString(current, str2);
                            if (!result.IsSuccess)
                            {
                                result = EolChar(current);
                            }
                        }
                    if (result.IsSuccess)
                    {
                        result = Result.Fail(current);
                    }
                    else
                    {
                        result = Result.Success(result, current);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // VisitAnyExpression:
                    {
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
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // string -> String
        public IResult String(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(3);
                // DropExpression:
                    // StringLiteralExpression:
                    var str = "\'";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        // StarExpression:
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // LiftExpression:
                                    result = Character(current);
                                    if (result.IsSuccess)
                                    {
                                        var nodes3 = new List<INode>();
                                        foreach (var node2 in result.Nodes)
                                        {
                                            nodes3.AddRange(node2.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes3.ToArray());
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes2.AddRange(result.Nodes);
                                    current = result.Next;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var location = Location.From(start, current);
                            var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                            result = Result.Success(location, current, node);
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>();
                            foreach (var node3 in result.Nodes)
                            {
                                nodes4.AddRange(node3.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            // StringLiteralExpression:
                            var str2 = "\'";
                            result = this.MatchString(current, str2);
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            return result;
        }
        
        // character -> Character
        public IResult Character(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                var result = StringVerbatim(current);
                if (!result.IsSuccess)
                {
                    result = Escape(current);
                    if (!result.IsSuccess)
                    {
                        result = UnicodeEscape(current);
                        if (!result.IsSuccess)
                        {
                            result = ByteEscape(current);
                        }
                    }
                }
            return result;
        }
        
        // string-verbatim -> StringVerbatim
        public IResult StringVerbatim(IContext context)
        {
            var current = context;
            IResult result;
            // FuseExpression:
            {
                // SequenceExpression:
                    var nodes = new List<INode>(2);
                    // NotExpression:
                        // ChoiceExpression:
                            // StringLiteralExpression:
                            var str = "\'";
                            result = this.MatchString(current, str);
                            if (!result.IsSuccess)
                            {
                                // StringLiteralExpression:
                                var str2 = "\\";
                                result = this.MatchString(current, str2);
                                if (!result.IsSuccess)
                                {
                                    result = EolChar(current);
                                }
                            }
                        if (result.IsSuccess)
                        {
                            result = Result.Fail(current);
                        }
                        else
                        {
                            result = Result.Success(result, current);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // VisitAnyExpression:
                        {
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
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node2 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node2);
                }
            }
            return result;
        }
        
        // escape -> Escape
        public IResult Escape(IContext context)
        {
            var current = context;
            IResult result;
            // FuseExpression:
            {
                // SequenceExpression:
                    var nodes = new List<INode>(2);
                    // DropExpression:
                        // StringLiteralExpression:
                        var str = "\\";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // ClassExpression
                        var values = new []{39,45,48,92,93,97,98,101,102,110,114,116,118};
                        result = this.MatchPredicate(current, (cur) => Array.BinarySearch(values, cur) >= 0);
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node);
                }
            }
            return result;
        }
        
        // unicode-escape -> UnicodeEscape
        public IResult UnicodeEscape(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(5);
                // DropExpression:
                    // SequenceExpression:
                        var nodes2 = new List<INode>(2);
                        // StringLiteralExpression:
                        var str = "\\u{";
                        var result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            nodes2.AddRange(result.Nodes);
                            current = result.Next;
                            result = _(current);
                            if (result.IsSuccess)
                            {
                                nodes2.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes2[0], current, nodes2.ToArray());
                            }
                        }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    result = UnicodeNumber(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            result = _(current);
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // StarExpression:
                                    var start = current;
                                    var nodes3 = new List<INode>();
                                    for (;;)
                                    {
                                        // SequenceExpression:
                                            var nodes4 = new List<INode>(2);
                                            result = UnicodeNumber(current);
                                            if (result.IsSuccess)
                                            {
                                                nodes4.AddRange(result.Nodes);
                                                current = result.Next;
                                                // DropExpression:
                                                    result = _(current);
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                if (result.IsSuccess)
                                                {
                                                    nodes4.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    result = Result.Success(nodes4[0], current, nodes4.ToArray());
                                                }
                                            }
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes3);
                                    result = Result.Success(location, current, node);
                                if (result.IsSuccess)
                                {
                                    var nodes5 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes5.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes5.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                    // StringLiteralExpression:
                                    var str2 = "}";
                                    result = this.MatchString(current, str2);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // unicode-number -> UnicodeNumber
        public IResult UnicodeNumber(IContext context)
        {
            var current = context;
            IResult result;
            // FuseExpression:
            {
                // SequenceExpression:
                    var nodes = new List<INode>(6);
                    result = HexDigit(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            // OptionalExpression:
                            {
                                result = HexDigit(current);
                                var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next, node);
                                }
                                else
                                {
                                    result = Result.Success(current, current, node);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes2.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // OptionalExpression:
                                {
                                    result = HexDigit(current);
                                    var node3 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next, node3);
                                    }
                                    else
                                    {
                                        result = Result.Success(current, current, node3);
                                    }
                                }
                                if (result.IsSuccess)
                                {
                                    var nodes3 = new List<INode>();
                                    foreach (var node4 in result.Nodes)
                                    {
                                        nodes3.AddRange(node4.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes3.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // LiftExpression:
                                    // OptionalExpression:
                                    {
                                        result = HexDigit(current);
                                        var node5 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next, node5);
                                        }
                                        else
                                        {
                                            result = Result.Success(current, current, node5);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        var nodes4 = new List<INode>();
                                        foreach (var node6 in result.Nodes)
                                        {
                                            nodes4.AddRange(node6.Children);
                                        }
                                        result = Result.Success(result, result.Next, nodes4.ToArray());
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    // LiftExpression:
                                        // OptionalExpression:
                                        {
                                            result = HexDigit(current);
                                            var node7 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                            if (result.IsSuccess)
                                            {
                                                result = Result.Success(result, result.Next, node7);
                                            }
                                            else
                                            {
                                                result = Result.Success(current, current, node7);
                                            }
                                        }
                                        if (result.IsSuccess)
                                        {
                                            var nodes5 = new List<INode>();
                                            foreach (var node8 in result.Nodes)
                                            {
                                                nodes5.AddRange(node8.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes5.ToArray());
                                        }
                                    if (result.IsSuccess)
                                    {
                                        nodes.AddRange(result.Nodes);
                                        current = result.Next;
                                        // LiftExpression:
                                            // OptionalExpression:
                                            {
                                                result = HexDigit(current);
                                                var node9 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                                                if (result.IsSuccess)
                                                {
                                                    result = Result.Success(result, result.Next, node9);
                                                }
                                                else
                                                {
                                                    result = Result.Success(current, current, node9);
                                                }
                                            }
                                            if (result.IsSuccess)
                                            {
                                                var nodes6 = new List<INode>();
                                                foreach (var node10 in result.Nodes)
                                                {
                                                    nodes6.AddRange(node10.Children);
                                                }
                                                result = Result.Success(result, result.Next, nodes6.ToArray());
                                            }
                                        if (result.IsSuccess)
                                        {
                                            nodes.AddRange(result.Nodes);
                                            current = result.Next;
                                            result = Result.Success(nodes[0], current, nodes.ToArray());
                                        }
                                    }
                                }
                            }
                        }
                    }
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node11 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node11);
                }
            }
            return result;
        }
        
        // byte-escape -> ByteEscape
        public IResult ByteEscape(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(5);
                // DropExpression:
                    // SequenceExpression:
                        var nodes2 = new List<INode>(2);
                        // StringLiteralExpression:
                        var str = "\\x{";
                        var result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            nodes2.AddRange(result.Nodes);
                            current = result.Next;
                            result = _(current);
                            if (result.IsSuccess)
                            {
                                nodes2.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes2[0], current, nodes2.ToArray());
                            }
                        }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    result = ByteNumber(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                            result = _(current);
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                                // StarExpression:
                                    var start = current;
                                    var nodes3 = new List<INode>();
                                    for (;;)
                                    {
                                        // SequenceExpression:
                                            var nodes4 = new List<INode>(2);
                                            result = ByteNumber(current);
                                            if (result.IsSuccess)
                                            {
                                                nodes4.AddRange(result.Nodes);
                                                current = result.Next;
                                                // DropExpression:
                                                    result = _(current);
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                if (result.IsSuccess)
                                                {
                                                    nodes4.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    result = Result.Success(nodes4[0], current, nodes4.ToArray());
                                                }
                                            }
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    var location = Location.From(start, current);
                                    var node = NodeList.From(location, NodeSymbols.Star, nodes3);
                                    result = Result.Success(location, current, node);
                                if (result.IsSuccess)
                                {
                                    var nodes5 = new List<INode>();
                                    foreach (var node2 in result.Nodes)
                                    {
                                        nodes5.AddRange(node2.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes5.ToArray());
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                    // StringLiteralExpression:
                                    var str2 = "}";
                                    result = this.MatchString(current, str2);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes.AddRange(result.Nodes);
                                    current = result.Next;
                                    result = Result.Success(nodes[0], current, nodes.ToArray());
                                }
                            }
                        }
                    }
                }
            return result;
        }
        
        // byte-number -> ByteNumber
        public IResult ByteNumber(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                var result = HexDigit(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                        // OptionalExpression:
                        {
                            result = HexDigit(current);
                            var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next, node);
                            }
                            else
                            {
                                result = Result.Success(current, current, node);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
                            foreach (var node2 in result.Nodes)
                            {
                                nodes2.AddRange(node2.Children);
                            }
                            result = Result.Success(result, result.Next, nodes2.ToArray());
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // character-class -> CharacterClass
        public IResult CharacterClass(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(4);
                // DropExpression:
                    // StringLiteralExpression:
                    var str = "[";
                    var result = this.MatchString(current, str);
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    result = Not(current);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            // StarExpression:
                                var start = current;
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    // LiftExpression:
                                        result = ClassPart(current);
                                        if (result.IsSuccess)
                                        {
                                            var nodes3 = new List<INode>();
                                            foreach (var node2 in result.Nodes)
                                            {
                                                nodes3.AddRange(node2.Children);
                                            }
                                            result = Result.Success(result, result.Next, nodes3.ToArray());
                                        }
                                    if (result.IsSuccess)
                                    {
                                        nodes2.AddRange(result.Nodes);
                                        current = result.Next;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                var location = Location.From(start, current);
                                var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                                result = Result.Success(location, current, node);
                            if (result.IsSuccess)
                            {
                                var nodes4 = new List<INode>();
                                foreach (var node3 in result.Nodes)
                                {
                                    nodes4.AddRange(node3.Children);
                                }
                                result = Result.Success(result, result.Next, nodes4.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                                // StringLiteralExpression:
                                var str2 = "]";
                                result = this.MatchString(current, str2);
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                }
            return result;
        }
        
        // not -> Not
        public IResult Not(IContext context)
        {
            var current = context;
            // LiftExpression:
                IResult result;
                // OptionalExpression:
                {
                    // StringLiteralExpression:
                    var str = "^";
                    result = this.MatchString(current, str);
                    var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next, node);
                    }
                    else
                    {
                        result = Result.Success(current, current, node);
                    }
                }
                if (result.IsSuccess)
                {
                    var nodes = new List<INode>();
                    foreach (var node2 in result.Nodes)
                    {
                        nodes.AddRange(node2.Children);
                    }
                    result = Result.Success(result, result.Next, nodes.ToArray());
                }
            return result;
        }
        
        // class-part -> ClassPart
        public IResult ClassPart(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                var result = Range(current);
                if (!result.IsSuccess)
                {
                    // LiftExpression:
                        result = ClassChar(current);
                        if (result.IsSuccess)
                        {
                            var nodes = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes.ToArray());
                        }
                }
            return result;
        }
        
        // range -> Range
        public IResult Range(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(3);
                // LiftExpression:
                    var result = ClassChar(current);
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                        // StringLiteralExpression:
                        var str = "-";
                        result = this.MatchString(current, str);
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                            result = ClassChar(current);
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>();
                                foreach (var node2 in result.Nodes)
                                {
                                    nodes3.AddRange(node2.Children);
                                }
                                result = Result.Success(result, result.Next, nodes3.ToArray());
                            }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            return result;
        }
        
        // class-char -> ClassChar
        public IResult ClassChar(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                var result = ClassVerbatim(current);
                if (!result.IsSuccess)
                {
                    result = Escape(current);
                    if (!result.IsSuccess)
                    {
                        result = UnicodeEscape(current);
                        if (!result.IsSuccess)
                        {
                            result = ByteEscape(current);
                        }
                    }
                }
            return result;
        }
        
        // class-verbatim -> ClassVerbatim
        public IResult ClassVerbatim(IContext context)
        {
            var current = context;
            IResult result;
            // FuseExpression:
            {
                // SequenceExpression:
                    var nodes = new List<INode>(2);
                    // NotExpression:
                        // ChoiceExpression:
                            // StringLiteralExpression:
                            var str = "]";
                            result = this.MatchString(current, str);
                            if (!result.IsSuccess)
                            {
                                // StringLiteralExpression:
                                var str2 = "\\";
                                result = this.MatchString(current, str2);
                                if (!result.IsSuccess)
                                {
                                    result = EolChar(current);
                                }
                            }
                        if (result.IsSuccess)
                        {
                            result = Result.Fail(current);
                        }
                        else
                        {
                            result = Result.Success(result, current);
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // VisitAnyExpression:
                        {
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
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                if (result.IsSuccess)
                {
                    var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                    var node2 = Leaf.From(result, NodeSymbols.Fusion, value);
                    result = Result.Success(result, result.Next, node2);
                }
            }
            return result;
        }
        
        // _ -> _
        public IResult _(IContext context)
        {
            var current = context;
            IResult result;
            // StarExpression:
                var start = current;
                var nodes = new List<INode>();
                for (;;)
                {
                    // ChoiceExpression:
                        result = Whitespace(current);
                        if (!result.IsSuccess)
                        {
                            result = Newline(current);
                            if (!result.IsSuccess)
                            {
                                result = Comment(current);
                            }
                        }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                var location = Location.From(start, current);
                var node = NodeList.From(location, NodeSymbols.Star, nodes);
                result = Result.Success(location, current, node);
            return result;
        }
        
        // comment -> Comment
        public IResult Comment(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                var result = SingleLineComment(current);
                if (!result.IsSuccess)
                {
                    result = MultiLineComment(current);
                }
            return result;
        }
        
        // single-line-comment -> SingleLineComment
        public IResult SingleLineComment(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(2);
                // StringLiteralExpression:
                var str = "//";
                var result = this.MatchString(current, str);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // StarExpression:
                        var start = current;
                        var nodes2 = new List<INode>();
                        for (;;)
                        {
                            // SequenceExpression:
                                var nodes3 = new List<INode>(2);
                                // NotExpression:
                                    result = EolChar(current);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Fail(current);
                                    }
                                    else
                                    {
                                        result = Result.Success(result, current);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes3.AddRange(result.Nodes);
                                    current = result.Next;
                                    // VisitAnyExpression:
                                    {
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
                                    }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                    }
                                }
                            if (result.IsSuccess)
                            {
                                nodes2.AddRange(result.Nodes);
                                current = result.Next;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var location = Location.From(start, current);
                        var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                        result = Result.Success(location, current, node);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            return result;
        }
        
        // multi-line-comment -> MultiLineComment
        public IResult MultiLineComment(IContext context)
        {
            var current = context;
            // SequenceExpression:
                var nodes = new List<INode>(3);
                // StringLiteralExpression:
                var str = "/*";
                var result = this.MatchString(current, str);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // StarExpression:
                        var start = current;
                        var nodes2 = new List<INode>();
                        for (;;)
                        {
                            // SequenceExpression:
                                var nodes3 = new List<INode>(2);
                                // NotExpression:
                                    // StringLiteralExpression:
                                    var str2 = "*/";
                                    result = this.MatchString(current, str2);
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Fail(current);
                                    }
                                    else
                                    {
                                        result = Result.Success(result, current);
                                    }
                                if (result.IsSuccess)
                                {
                                    nodes3.AddRange(result.Nodes);
                                    current = result.Next;
                                    // VisitAnyExpression:
                                    {
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
                                    }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                    }
                                }
                            if (result.IsSuccess)
                            {
                                nodes2.AddRange(result.Nodes);
                                current = result.Next;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var location = Location.From(start, current);
                        var node = NodeList.From(location, NodeSymbols.Star, nodes2);
                        result = Result.Success(location, current, node);
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // StringLiteralExpression:
                        var str3 = "*/";
                        result = this.MatchString(current, str3);
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            result = Result.Success(nodes[0], current, nodes.ToArray());
                        }
                    }
                }
            return result;
        }
        
        // newline -> Newline
        public IResult Newline(IContext context)
        {
            var current = context;
            // ChoiceExpression:
                // StringLiteralExpression:
                var str = "\n";
                var result = this.MatchString(current, str);
                if (!result.IsSuccess)
                {
                    // StringLiteralExpression:
                    var str2 = "\r\n";
                    result = this.MatchString(current, str2);
                    if (!result.IsSuccess)
                    {
                        // StringLiteralExpression:
                        var str3 = "\r";
                        result = this.MatchString(current, str3);
                        if (!result.IsSuccess)
                        {
                            // StringLiteralExpression:
                            var str4 = "\u2028";
                            result = this.MatchString(current, str4);
                            if (!result.IsSuccess)
                            {
                                // StringLiteralExpression:
                                var str5 = "\u2029";
                                result = this.MatchString(current, str5);
                            }
                        }
                    }
                }
            return result;
        }
        
        // eol-char -> EolChar
        public IResult EolChar(IContext context)
        {
            var current = context;
            // ClassExpression
            var values = new []{10,13,8232,8233};
            var result = this.MatchPredicate(current, (cur) => Array.IndexOf(values, cur) >= 0);
            return result;
        }
        
        // whitespace -> Whitespace
        public IResult Whitespace(IContext context)
        {
            var current = context;
            // ClassExpression
            var values = new []{9,11,12,32,160,5760,6158,8192,8193,8194,8195,8196,8197,8198,8199,8200,8201,8202,8239,8287,12288,65279};
            var result = this.MatchPredicate(current, (cur) => Array.BinarySearch(values, cur) >= 0);
            return result;
        }
    }
}
