namespace Lipeg.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Lipeg.SDK.Parsers;
    using Lipeg.SDK.Tree;
    using Lipeg.Runtime;
    
    public partial class LipegParser
    {
        // start -> Start
        public IResult Start(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // NameExpression:
                {
                    result = Grammar(current);
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // NameExpression:
                    {
                        result = Eof(current);
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
        
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(5);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "grammar";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // NameExpression:
                    {
                        result = Identifier(current);
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                        {
                            // StringLiteralExpression:
                            {
                                var str2 = "{";
                                if (current.StartsWith(str2))
                                {
                                    var next2 = current.Advance(str2.Length);
                                    var location2 = Location.From(current, next2);
                                    var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                    result = Result.Success(location2, next2, node2);
                                    current = next2;
                                }
                                else
                                {
                                    result = Result.Fail(current);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                            {
                                // StarExpression:
                                {
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // ChoiceExpression:
                                        {
                                            // NameExpression:
                                            {
                                                result = Options(current);
                                            }
                                            if (!result.IsSuccess)
                                            {
                                                // NameExpression:
                                                {
                                                    result = Syntax(current);
                                                }
                                                if (!result.IsSuccess)
                                                {
                                                    // NameExpression:
                                                    {
                                                        result = Lexical(current);
                                                    }
                                                }
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
                                    var location3 = Location.From(start, current);
                                    var node3 = NodeList.From(location3, NodeSymbols.Star, nodes2);
                                    result = Result.Success(location3, current, node3);
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
                            }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                {
                                    // StringLiteralExpression:
                                    {
                                        var str3 = "}";
                                        if (current.StartsWith(str3))
                                        {
                                            var next3 = current.Advance(str3.Length);
                                            var location4 = Location.From(current, next3);
                                            var node5 = Leaf.From(location4, NodeSymbols.StringLiteral, str3);
                                            result = Result.Success(location4, next3, node5);
                                            current = next3;
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
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
            return result;
        }
        
        // options -> Options
        public IResult Options(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(4);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "options";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str2 = "{";
                            if (current.StartsWith(str2))
                            {
                                var next2 = current.Advance(str2.Length);
                                var location2 = Location.From(current, next2);
                                var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                result = Result.Success(location2, next2, node2);
                                current = next2;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                        {
                            // StarExpression:
                            {
                                var start = current;
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    // NameExpression:
                                    {
                                        result = Option(current);
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
                                var location3 = Location.From(start, current);
                                var node3 = NodeList.From(location3, NodeSymbols.Star, nodes2);
                                result = Result.Success(location3, current, node3);
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
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                            {
                                // StringLiteralExpression:
                                {
                                    var str3 = "}";
                                    if (current.StartsWith(str3))
                                    {
                                        var next3 = current.Advance(str3.Length);
                                        var location4 = Location.From(current, next3);
                                        var node5 = Leaf.From(location4, NodeSymbols.StringLiteral, str3);
                                        result = Result.Success(location4, next3, node5);
                                        current = next3;
                                    }
                                    else
                                    {
                                        result = Result.Fail(current);
                                    }
                                }
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
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
        
        // option -> Option
        public IResult Option(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(4);
                // NameExpression:
                {
                    result = Identifier(current);
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str = "=";
                            if (current.StartsWith(str))
                            {
                                var next = current.Advance(str.Length);
                                var location = Location.From(current, next);
                                var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                result = Result.Success(location, next, node);
                                current = next;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // NameExpression:
                        {
                            result = OptionValue(current);
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                            {
                                // StringLiteralExpression:
                                {
                                    var str2 = ";";
                                    if (current.StartsWith(str2))
                                    {
                                        var next2 = current.Advance(str2.Length);
                                        var location2 = Location.From(current, next2);
                                        var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                        result = Result.Success(location2, next2, node2);
                                        current = next2;
                                    }
                                    else
                                    {
                                        result = Result.Fail(current);
                                    }
                                }
                                if (result.IsSuccess)
                                {
                                    result = Result.Success(result, result.Next);
                                }
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
        
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            var current = context;
            IResult result;
            // NameExpression:
            {
                result = QualifiedIdentifier(current);
            }
            return result;
        }
        
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // NameExpression:
                {
                    result = Identifier(current);
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // StarExpression:
                        {
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // SequenceExpression:
                                {
                                    var nodes3 = new List<INode>(2);
                                    // DropExpression:
                                    {
                                        // StringLiteralExpression:
                                        {
                                            var str = ".";
                                            if (current.StartsWith(str))
                                            {
                                                var next = current.Advance(str.Length);
                                                var location2 = Location.From(current, next);
                                                var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str);
                                                result = Result.Success(location2, next, node2);
                                                current = next;
                                            }
                                            else
                                            {
                                                result = Result.Fail(current);
                                            }
                                        }
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        // NameExpression:
                                        {
                                            result = Identifier(current);
                                        }
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
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
                        }
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>();
                            foreach (var node3 in result.Nodes)
                            {
                                nodes4.AddRange(node3.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
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
        
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(5);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "syntax";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str2 = "{";
                            if (current.StartsWith(str2))
                            {
                                var next2 = current.Advance(str2.Length);
                                var location2 = Location.From(current, next2);
                                var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                result = Result.Success(location2, next2, node2);
                                current = next2;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                        {
                            // NameExpression:
                            {
                                result = Rules(current);
                            }
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node3 in result.Nodes)
                                {
                                    nodes2.AddRange(node3.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                            {
                                // OptionalExpression:
                                {
                                    // StringLiteralExpression:
                                    {
                                        var str3 = ";";
                                        if (current.StartsWith(str3))
                                        {
                                            var next3 = current.Advance(str3.Length);
                                            var location3 = Location.From(current, next3);
                                            var node4 = Leaf.From(location3, NodeSymbols.StringLiteral, str3);
                                            result = Result.Success(location3, next3, node4);
                                            current = next3;
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    }
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
                                    result = Result.Success(result, result.Next);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                {
                                    // StringLiteralExpression:
                                    {
                                        var str4 = "}";
                                        if (current.StartsWith(str4))
                                        {
                                            var next4 = current.Advance(str4.Length);
                                            var location4 = Location.From(current, next4);
                                            var node6 = Leaf.From(location4, NodeSymbols.StringLiteral, str4);
                                            result = Result.Success(location4, next4, node6);
                                            current = next4;
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
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
            return result;
        }
        
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(5);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "lexical";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str2 = "{";
                            if (current.StartsWith(str2))
                            {
                                var next2 = current.Advance(str2.Length);
                                var location2 = Location.From(current, next2);
                                var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                result = Result.Success(location2, next2, node2);
                                current = next2;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // LiftExpression:
                        {
                            // NameExpression:
                            {
                                result = Rules(current);
                            }
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node3 in result.Nodes)
                                {
                                    nodes2.AddRange(node3.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
                            }
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // DropExpression:
                            {
                                // OptionalExpression:
                                {
                                    // StringLiteralExpression:
                                    {
                                        var str3 = ";";
                                        if (current.StartsWith(str3))
                                        {
                                            var next3 = current.Advance(str3.Length);
                                            var location3 = Location.From(current, next3);
                                            var node4 = Leaf.From(location3, NodeSymbols.StringLiteral, str3);
                                            result = Result.Success(location3, next3, node4);
                                            current = next3;
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    }
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
                                    result = Result.Success(result, result.Next);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                // DropExpression:
                                {
                                    // StringLiteralExpression:
                                    {
                                        var str4 = "}";
                                        if (current.StartsWith(str4))
                                        {
                                            var next4 = current.Advance(str4.Length);
                                            var location4 = Location.From(current, next4);
                                            var node6 = Leaf.From(location4, NodeSymbols.StringLiteral, str4);
                                            result = Result.Success(location4, next4, node6);
                                            current = next4;
                                        }
                                        else
                                        {
                                            result = Result.Fail(current);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        result = Result.Success(result, result.Next);
                                    }
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
            return result;
        }
        
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            var current = context;
            IResult result;
            // LiftExpression:
            {
                // OptionalExpression:
                {
                    // SequenceExpression:
                    {
                        var nodes = new List<INode>(2);
                        // NameExpression:
                        {
                            result = Rule(current);
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                            {
                                // StarExpression:
                                {
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // SequenceExpression:
                                        {
                                            var nodes3 = new List<INode>(2);
                                            // DropExpression:
                                            {
                                                // StringLiteralExpression:
                                                {
                                                    var str = ";";
                                                    if (current.StartsWith(str))
                                                    {
                                                        var next = current.Advance(str.Length);
                                                        var location2 = Location.From(current, next);
                                                        var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str);
                                                        result = Result.Success(location2, next, node2);
                                                        current = next;
                                                    }
                                                    else
                                                    {
                                                        result = Result.Fail(current);
                                                    }
                                                }
                                                if (result.IsSuccess)
                                                {
                                                    result = Result.Success(result, result.Next);
                                                }
                                            }
                                            if (result.IsSuccess)
                                            {
                                                nodes3.AddRange(result.Nodes);
                                                current = result.Next;
                                                // NameExpression:
                                                {
                                                    result = Rule(current);
                                                }
                                                if (result.IsSuccess)
                                                {
                                                    nodes3.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                                }
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
                                }
                                if (result.IsSuccess)
                                {
                                    var nodes4 = new List<INode>();
                                    foreach (var node3 in result.Nodes)
                                    {
                                        nodes4.AddRange(node3.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes4.ToArray());
                                }
                            }
                            if (result.IsSuccess)
                            {
                                nodes.AddRange(result.Nodes);
                                current = result.Next;
                                result = Result.Success(nodes[0], current, nodes.ToArray());
                            }
                        }
                    }
                    var node4 = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next, node4);
                    }
                    else
                    {
                        result = Result.Success(current, current, node4);
                    }
                }
                if (result.IsSuccess)
                {
                    var nodes5 = new List<INode>();
                    foreach (var node5 in result.Nodes)
                    {
                        nodes5.AddRange(node5.Children);
                    }
                    result = Result.Success(result, result.Next, nodes5.ToArray());
                }
            }
            return result;
        }
        
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(4);
                // NameExpression:
                {
                    result = Identifier(current);
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str = "<=";
                            if (current.StartsWith(str))
                            {
                                var next = current.Advance(str.Length);
                                var location = Location.From(current, next);
                                var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                result = Result.Success(location, next, node);
                                current = next;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                        {
                            // OptionalExpression:
                            {
                                // StringLiteralExpression:
                                {
                                    var str2 = "/";
                                    if (current.StartsWith(str2))
                                    {
                                        var next2 = current.Advance(str2.Length);
                                        var location2 = Location.From(current, next2);
                                        var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                        result = Result.Success(location2, next2, node2);
                                        current = next2;
                                    }
                                    else
                                    {
                                        result = Result.Fail(current);
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
                                result = Result.Success(result, result.Next);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            nodes.AddRange(result.Nodes);
                            current = result.Next;
                            // LiftExpression:
                            {
                                // NameExpression:
                                {
                                    result = Expression(current);
                                }
                                if (result.IsSuccess)
                                {
                                    var nodes2 = new List<INode>();
                                    foreach (var node4 in result.Nodes)
                                    {
                                        nodes2.AddRange(node4.Children);
                                    }
                                    result = Result.Success(result, result.Next, nodes2.ToArray());
                                }
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
        
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
                // NameExpression:
                {
                    result = Choice(current);
                }
                if (!result.IsSuccess)
                {
                    // NameExpression:
                    {
                        result = Sequence(current);
                    }
                }
            }
            return result;
        }
        
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // NameExpression:
                {
                    result = Sequence(current);
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // PlusExpression:
                        {
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // SequenceExpression:
                                {
                                    var nodes3 = new List<INode>(2);
                                    // DropExpression:
                                    {
                                        // StringLiteralExpression:
                                        {
                                            var str = "/";
                                            if (current.StartsWith(str))
                                            {
                                                var next = current.Advance(str.Length);
                                                var location = Location.From(current, next);
                                                var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                                result = Result.Success(location, next, node);
                                                current = next;
                                            }
                                            else
                                            {
                                                result = Result.Fail(current);
                                            }
                                        }
                                        if (result.IsSuccess)
                                        {
                                            result = Result.Success(result, result.Next);
                                        }
                                    }
                                    if (result.IsSuccess)
                                    {
                                        nodes3.AddRange(result.Nodes);
                                        current = result.Next;
                                        // NameExpression:
                                        {
                                            result = Sequence(current);
                                        }
                                        if (result.IsSuccess)
                                        {
                                            nodes3.AddRange(result.Nodes);
                                            current = result.Next;
                                            result = Result.Success(nodes3[0], current, nodes3.ToArray());
                                        }
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
                                var location2 = Location.From(start, current);
                                var node2 = NodeList.From(location2, NodeSymbols.Plus, nodes2.ToArray());
                                result = Result.Success(location2, current, node2);
                            }
                            else
                            {
                                result = Result.Fail(start);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            var nodes4 = new List<INode>();
                            foreach (var node3 in result.Nodes)
                            {
                                nodes4.AddRange(node3.Children);
                            }
                            result = Result.Success(result, result.Next, nodes4.ToArray());
                        }
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
        
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            var current = context;
            IResult result;
            // LiftExpression:
            {
                // PlusExpression:
                {
                    var start = current;
                    var nodes = new List<INode>();
                    for (;;)
                    {
                        // LiftExpression:
                        {
                            // NameExpression:
                            {
                                result = Prefix(current);
                            }
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
                                foreach (var node in result.Nodes)
                                {
                                    nodes2.AddRange(node.Children);
                                }
                                result = Result.Success(result, result.Next, nodes2.ToArray());
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
            }
            return result;
        }
        
        // prefix -> Prefix
        public IResult Prefix(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
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
                                    {
                                        // NameExpression:
                                        {
                                            result = Suffix(current);
                                        }
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
                }
            }
            return result;
        }
        
        // suffix -> Suffix
        public IResult Suffix(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
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
                            {
                                // NameExpression:
                                {
                                    result = Primary(current);
                                }
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
        
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
                // NameExpression:
                {
                    result = Identifier(current);
                }
                if (!result.IsSuccess)
                {
                    // NameExpression:
                    {
                        result = VerbatimString(current);
                    }
                    if (!result.IsSuccess)
                    {
                        // NameExpression:
                        {
                            result = String(current);
                        }
                        if (!result.IsSuccess)
                        {
                            // NameExpression:
                            {
                                result = CharacterClass(current);
                            }
                            if (!result.IsSuccess)
                            {
                                // NameExpression:
                                {
                                    result = Any(current);
                                }
                                if (!result.IsSuccess)
                                {
                                    // NameExpression:
                                    {
                                        result = Epsilon(current);
                                    }
                                    if (!result.IsSuccess)
                                    {
                                        // NameExpression:
                                        {
                                            result = Inline(current);
                                        }
                                        if (!result.IsSuccess)
                                        {
                                            // SequenceExpression:
                                            {
                                                var nodes = new List<INode>(3);
                                                // DropExpression:
                                                {
                                                    // StringLiteralExpression:
                                                    {
                                                        var str = "(";
                                                        if (current.StartsWith(str))
                                                        {
                                                            var next = current.Advance(str.Length);
                                                            var location = Location.From(current, next);
                                                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                                            result = Result.Success(location, next, node);
                                                            current = next;
                                                        }
                                                        else
                                                        {
                                                            result = Result.Fail(current);
                                                        }
                                                    }
                                                    if (result.IsSuccess)
                                                    {
                                                        result = Result.Success(result, result.Next);
                                                    }
                                                }
                                                if (result.IsSuccess)
                                                {
                                                    nodes.AddRange(result.Nodes);
                                                    current = result.Next;
                                                    // LiftExpression:
                                                    {
                                                        // NameExpression:
                                                        {
                                                            result = Expression(current);
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
                                                    }
                                                    if (result.IsSuccess)
                                                    {
                                                        nodes.AddRange(result.Nodes);
                                                        current = result.Next;
                                                        // DropExpression:
                                                        {
                                                            // StringLiteralExpression:
                                                            {
                                                                var str2 = ")";
                                                                if (current.StartsWith(str2))
                                                                {
                                                                    var next2 = current.Advance(str2.Length);
                                                                    var location2 = Location.From(current, next2);
                                                                    var node3 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                                                    result = Result.Success(location2, next2, node3);
                                                                    current = next2;
                                                                }
                                                                else
                                                                {
                                                                    result = Result.Fail(current);
                                                                }
                                                            }
                                                            if (result.IsSuccess)
                                                            {
                                                                result = Result.Success(result, result.Next);
                                                            }
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
                }
            }
            return result;
        }
        
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(3);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "(";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Rule(current);
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
                    }
                    if (result.IsSuccess)
                    {
                        nodes.AddRange(result.Nodes);
                        current = result.Next;
                        // DropExpression:
                        {
                            // StringLiteralExpression:
                            {
                                var str2 = ")";
                                if (current.StartsWith(str2))
                                {
                                    var next2 = current.Advance(str2.Length);
                                    var location2 = Location.From(current, next2);
                                    var node3 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                                    result = Result.Success(location2, next2, node3);
                                    current = next2;
                                }
                                else
                                {
                                    result = Result.Fail(current);
                                }
                            }
                            if (result.IsSuccess)
                            {
                                result = Result.Success(result, result.Next);
                            }
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
        
        // any -> Any
        public IResult Any(IContext context)
        {
            var current = context;
            IResult result;
            // DropExpression:
            {
                // StringLiteralExpression:
                {
                    var str = ".";
                    if (current.StartsWith(str))
                    {
                        var next = current.Advance(str.Length);
                        var location = Location.From(current, next);
                        var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                        result = Result.Success(location, next, node);
                        current = next;
                    }
                    else
                    {
                        result = Result.Fail(current);
                    }
                }
                if (result.IsSuccess)
                {
                    result = Result.Success(result, result.Next);
                }
            }
            return result;
        }
        
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
                // StringLiteralExpression:
                {
                    var str = "epsilon";
                    if (current.StartsWith(str))
                    {
                        var next = current.Advance(str.Length);
                        var location = Location.From(current, next);
                        var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                        result = Result.Success(location, next, node);
                        current = next;
                    }
                    else
                    {
                        result = Result.Fail(current);
                    }
                }
                if (!result.IsSuccess)
                {
                    // StringLiteralExpression:
                    {
                        var str2 = "ε";
                        if (current.StartsWith(str2))
                        {
                            var next2 = current.Advance(str2.Length);
                            var location2 = Location.From(current, next2);
                            var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                            result = Result.Success(location2, next2, node2);
                            current = next2;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                }
            }
            return result;
        }
        
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            var current = context;
            IResult result;
            // NotExpression:
            {
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
                    result = Result.Success(result, current);
                }
                else
                {
                    result = Result.Fail(current);
                }
            }
            return result;
        }
        
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "&";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Suffix(current);
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
        
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "!";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Suffix(current);
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
        
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = ",";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Suffix(current);
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
        
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "~";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Suffix(current);
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
        
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // DropExpression:
                {
                    // StringLiteralExpression:
                    {
                        var str = "^";
                        if (current.StartsWith(str))
                        {
                            var next = current.Advance(str.Length);
                            var location = Location.From(current, next);
                            var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                            result = Result.Success(location, next, node);
                            current = next;
                        }
                        else
                        {
                            result = Result.Fail(current);
                        }
                    }
                    if (result.IsSuccess)
                    {
                        result = Result.Success(result, result.Next);
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // LiftExpression:
                    {
                        // NameExpression:
                        {
                            result = Suffix(current);
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
        
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // LiftExpression:
                {
                    // NameExpression:
                    {
                        result = Primary(current);
                    }
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str = "?";
                            if (current.StartsWith(str))
                            {
                                var next = current.Advance(str.Length);
                                var location = Location.From(current, next);
                                var node2 = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                result = Result.Success(location, next, node2);
                                current = next;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
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
        
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // LiftExpression:
                {
                    // NameExpression:
                    {
                        result = Primary(current);
                    }
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str = "*";
                            if (current.StartsWith(str))
                            {
                                var next = current.Advance(str.Length);
                                var location = Location.From(current, next);
                                var node2 = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                result = Result.Success(location, next, node2);
                                current = next;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
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
        
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            var current = context;
            IResult result;
            // SequenceExpression:
            {
                var nodes = new List<INode>(2);
                // LiftExpression:
                {
                    // NameExpression:
                    {
                        result = Primary(current);
                    }
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
                        foreach (var node in result.Nodes)
                        {
                            nodes2.AddRange(node.Children);
                        }
                        result = Result.Success(result, result.Next, nodes2.ToArray());
                    }
                }
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                    // DropExpression:
                    {
                        // StringLiteralExpression:
                        {
                            var str = "+";
                            if (current.StartsWith(str))
                            {
                                var next = current.Advance(str.Length);
                                var location = Location.From(current, next);
                                var node2 = Leaf.From(location, NodeSymbols.StringLiteral, str);
                                result = Result.Success(location, next, node2);
                                current = next;
                            }
                            else
                            {
                                result = Result.Fail(current);
                            }
                        }
                        if (result.IsSuccess)
                        {
                            result = Result.Success(result, result.Next);
                        }
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
        
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            var current = context;
            IResult result;
            // ChoiceExpression:
            {
                VisitFuseExpression
                if (!result.IsSuccess)
                {
                    VisitFuseExpression
                }
            }
            return result;
        }
        
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            var current = context;
            VisitClassExpression
            return var result;
        }
        
        // letter-or-digit -> LetterOrDigit
        public IResult LetterOrDigit(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // hex-digit -> HexDigit
        public IResult HexDigit(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // verbatim-string -> VerbatimString
        public IResult VerbatimString(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // verbatim-character -> VerbatimCharacter
        public IResult VerbatimCharacter(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // string -> String
        public IResult String(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // character -> Character
        public IResult Character(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // string-verbatim -> StringVerbatim
        public IResult StringVerbatim(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // escape -> Escape
        public IResult Escape(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // unicode-escape -> UnicodeEscape
        public IResult UnicodeEscape(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // unicode-number -> UnicodeNumber
        public IResult UnicodeNumber(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // byte-escape -> ByteEscape
        public IResult ByteEscape(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // byte-number -> ByteNumber
        public IResult ByteNumber(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // character-class -> CharacterClass
        public IResult CharacterClass(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // not -> Not
        public IResult Not(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // class-part -> ClassPart
        public IResult ClassPart(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // range -> Range
        public IResult Range(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // class-char -> ClassChar
        public IResult ClassChar(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // class-verbatim -> ClassVerbatim
        public IResult ClassVerbatim(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // _ -> _
        public IResult _(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // comment -> Comment
        public IResult Comment(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // single-line-comment -> SingleLineComment
        public IResult SingleLineComment(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // multi-line-comment -> MultiLineComment
        public IResult MultiLineComment(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // newline -> Newline
        public IResult Newline(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // eol-char -> EolChar
        public IResult EolChar(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // whitespace -> Whitespace
        public IResult Whitespace(IContext context)
        {
            throw new NotImplementedException();
        }
    }
}
