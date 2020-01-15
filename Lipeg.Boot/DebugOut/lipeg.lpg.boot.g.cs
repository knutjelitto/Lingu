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
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{NameExpression
                    var result = Grammar(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{NameExpression
                        result = Eof(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        result = Result.Success(nodes[0], current, nodes.ToArray());
                    }
                }
            // }}SequenceExpression
            return result;
        }
        
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "grammar";
                        var result = this.__MatchString(current, str);
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
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{NameExpression
                        result = Identifier(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{SPACE
                                /*SKIP SPACE*/ current = _(current).Next;
                            // }}SPACE
                            // {{StringLiteralExpression
                                var str2 = "{";
                                result = this.__MatchString(current, str2);
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
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // {{ChoiceExpression
                                            // {{NameExpression
                                                result = Options(current);
                                            // }}NameExpression
                                            if (!result.IsSuccess)
                                            {
                                                // {{NameExpression
                                                    result = Syntax(current);
                                                // }}NameExpression
                                                if (!result.IsSuccess)
                                                {
                                                    // {{NameExpression
                                                        result = Lexical(current);
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
                                    var nodes3 = new List<INode>();
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
                                    // {{SPACE
                                        /*SKIP SPACE*/ current = _(current).Next;
                                    // }}SPACE
                                    // {{StringLiteralExpression
                                        var str3 = "}";
                                        result = this.__MatchString(current, str3);
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
            return result;
        }
        
        // options -> Options
        public IResult Options(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "options";
                        var result = this.__MatchString(current, str);
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str2 = "{";
                            result = this.__MatchString(current, str2);
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
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    // {{NameExpression
                                        result = Option(current);
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
                                var nodes3 = new List<INode>();
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
                                // {{SPACE
                                    /*SKIP SPACE*/ current = _(current).Next;
                                // }}SPACE
                                // {{StringLiteralExpression
                                    var str3 = "}";
                                    result = this.__MatchString(current, str3);
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
            return result;
        }
        
        // option -> Option
        public IResult Option(IContext context)
        {
            var current = context;
            // {{SPACE
                /*SKIP SPACE*/ current = _(current).Next;
            // }}SPACE
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{NameExpression
                    var result = Identifier(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str = "=";
                            result = this.__MatchString(current, str);
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
                            result = OptionValue(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{DropExpression
                                // {{SPACE
                                    /*SKIP SPACE*/ current = _(current).Next;
                                // }}SPACE
                                // {{StringLiteralExpression
                                    var str2 = ";";
                                    result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            var current = context;
            // {{NameExpression
                var result = QualifiedIdentifier(current);
            // }}NameExpression
            return result;
        }
        
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            var current = context;
            // {{SPACE
                /*SKIP SPACE*/ current = _(current).Next;
            // }}SPACE
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{NameExpression
                    var result = Identifier(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{StarExpression
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // {{SequenceExpression
                                    var nodes3 = new List<INode>();
                                    // {{DropExpression
                                        // {{SPACE
                                            /*SKIP SPACE*/ current = _(current).Next;
                                        // }}SPACE
                                        // {{StringLiteralExpression
                                            var str = ".";
                                            result = this.__MatchString(current, str);
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
                                        // {{SPACE
                                            /*SKIP SPACE*/ current = _(current).Next;
                                        // }}SPACE
                                        // {{NameExpression
                                            result = Identifier(current);
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
                            var nodes4 = new List<INode>();
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
            return result;
        }
        
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "syntax";
                        var result = this.__MatchString(current, str);
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str2 = "{";
                            result = this.__MatchString(current, str2);
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
                                result = Rules(current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
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
                                // {{SPACE
                                    /*SKIP SPACE*/ current = _(current).Next;
                                // }}SPACE
                                // {{OptionalExpression
                                    // {{SPACE
                                        /*SKIP SPACE*/ current = _(current).Next;
                                    // }}SPACE
                                    // {{StringLiteralExpression
                                        var str3 = ";";
                                        result = this.__MatchString(current, str3);
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
                                    // {{SPACE
                                        /*SKIP SPACE*/ current = _(current).Next;
                                    // }}SPACE
                                    // {{StringLiteralExpression
                                        var str4 = "}";
                                        result = this.__MatchString(current, str4);
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
            return result;
        }
        
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "lexical";
                        var result = this.__MatchString(current, str);
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str2 = "{";
                            result = this.__MatchString(current, str2);
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
                                result = Rules(current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
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
                                // {{SPACE
                                    /*SKIP SPACE*/ current = _(current).Next;
                                // }}SPACE
                                // {{OptionalExpression
                                    // {{SPACE
                                        /*SKIP SPACE*/ current = _(current).Next;
                                    // }}SPACE
                                    // {{StringLiteralExpression
                                        var str3 = ";";
                                        result = this.__MatchString(current, str3);
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
                                    // {{SPACE
                                        /*SKIP SPACE*/ current = _(current).Next;
                                    // }}SPACE
                                    // {{StringLiteralExpression
                                        var str4 = "}";
                                        result = this.__MatchString(current, str4);
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
            return result;
        }
        
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{OptionalExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>();
                        // {{NameExpression
                            var result = Rule(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes3 = new List<INode>();
                                            // {{DropExpression
                                                // {{SPACE
                                                    /*SKIP SPACE*/ current = _(current).Next;
                                                // }}SPACE
                                                // {{StringLiteralExpression
                                                    var str = ";";
                                                    result = this.__MatchString(current, str);
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
                                                    result = Rule(current);
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
                                    var nodes4 = new List<INode>();
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
                    var nodes5 = new List<INode>();
                    foreach (var node4 in result.Nodes)
                    {
                        nodes5.AddRange(node4.Children);
                    }
                    result = Result.Success(result, result.Next, nodes5.ToArray());
                }
            // }}LiftExpression
            return result;
        }
        
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            var current = context;
            // {{SPACE
                /*SKIP SPACE*/ current = _(current).Next;
            // }}SPACE
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{NameExpression
                    var result = Identifier(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{DropExpression
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str = "<=";
                            result = this.__MatchString(current, str);
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
                            // {{SPACE
                                /*SKIP SPACE*/ current = _(current).Next;
                            // }}SPACE
                            // {{OptionalExpression
                                // {{SPACE
                                    /*SKIP SPACE*/ current = _(current).Next;
                                // }}SPACE
                                // {{StringLiteralExpression
                                    var str2 = "/";
                                    result = this.__MatchString(current, str2);
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
                                    result = Expression(current);
                                // }}NameExpression
                                if (result.IsSuccess)
                                {
                                    var nodes2 = new List<INode>();
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
            return result;
        }
        
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = Choice(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = Sequence(current);
                    // }}NameExpression
                }
            // }}ChoiceExpression
            return result;
        }
        
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{NameExpression
                    var result = Sequence(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{PlusExpression
                            var start = current;
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // {{SequenceExpression
                                    var nodes3 = new List<INode>();
                                    // {{DropExpression
                                        // {{SPACE
                                            /*SKIP SPACE*/ current = _(current).Next;
                                        // }}SPACE
                                        // {{StringLiteralExpression
                                            var str = "/";
                                            result = this.__MatchString(current, str);
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
                                            result = Sequence(current);
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
                            var nodes4 = new List<INode>();
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
            return result;
        }
        
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{PlusExpression
                    var start = current;
                    var nodes = new List<INode>();
                    IResult result;
                    for (;;)
                    {
                        // {{LiftExpression
                            // {{NameExpression
                                result = Prefix(current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes2 = new List<INode>();
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
                    var nodes3 = new List<INode>();
                    foreach (var node3 in result.Nodes)
                    {
                        nodes3.AddRange(node3.Children);
                    }
                    result = Result.Success(result, result.Next, nodes3.ToArray());
                }
            // }}LiftExpression
            return result;
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
                                            result = Suffix(current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            var nodes = new List<INode>();
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
            return result;
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
                                    result = Primary(current);
                                // }}NameExpression
                                if (result.IsSuccess)
                                {
                                    var nodes = new List<INode>();
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
            return result;
        }
        
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{NameExpression
                    var result = Identifier(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{NameExpression
                        result = VerbatimString(current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{NameExpression
                            result = String(current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{SPACE
                                /*SKIP SPACE*/ current = _(current).Next;
                            // }}SPACE
                            // {{NameExpression
                                result = CharacterClass(current);
                            // }}NameExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = Any(current);
                                // }}NameExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = Epsilon(current);
                                    // }}NameExpression
                                    if (!result.IsSuccess)
                                    {
                                        // {{NameExpression
                                            result = Inline(current);
                                        // }}NameExpression
                                        if (!result.IsSuccess)
                                        {
                                            // {{SequenceExpression
                                                var nodes = new List<INode>();
                                                // {{DropExpression
                                                    // {{SPACE
                                                        /*SKIP SPACE*/ current = _(current).Next;
                                                    // }}SPACE
                                                    // {{StringLiteralExpression
                                                        var str = "(";
                                                        result = this.__MatchString(current, str);
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
                                                            result = Expression(current);
                                                        // }}NameExpression
                                                        if (result.IsSuccess)
                                                        {
                                                            var nodes2 = new List<INode>();
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
                                                            // {{SPACE
                                                                /*SKIP SPACE*/ current = _(current).Next;
                                                            // }}SPACE
                                                            // {{StringLiteralExpression
                                                                var str2 = ")";
                                                                result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "(";
                        var result = this.__MatchString(current, str);
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
                            result = Rule(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
                            // {{SPACE
                                /*SKIP SPACE*/ current = _(current).Next;
                            // }}SPACE
                            // {{StringLiteralExpression
                                var str2 = ")";
                                result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // any -> Any
        public IResult Any(IContext context)
        {
            var current = context;
            // {{DropExpression
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{StringLiteralExpression
                    var str = ".";
                    var result = this.__MatchString(current, str);
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    result = Result.Success(result, result.Next);
                }
            // }}DropExpression
            return result;
        }
        
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            var current = context;
            // {{SPACE
                /*SKIP SPACE*/ current = _(current).Next;
            // }}SPACE
            // {{ChoiceExpression
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
                // {{StringLiteralExpression
                    var str = "epsilon";
                    var result = this.__MatchString(current, str);
                // }}StringLiteralExpression
                if (!result.IsSuccess)
                {
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str2 = "ε";
                        result = this.__MatchString(current, str2);
                    // }}StringLiteralExpression
                }
            // }}ChoiceExpression
            return result;
        }
        
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            var current = context;
            // {{SPACE
                /*SKIP SPACE*/ current = _(current).Next;
            // }}SPACE
            // {{NotExpression
                IResult result;
                // {{SPACE
                    /*SKIP SPACE*/ current = _(current).Next;
                // }}SPACE
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
            return result;
        }
        
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "&";
                        var result = this.__MatchString(current, str);
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
                            result = Suffix(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "!";
                        var result = this.__MatchString(current, str);
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
                            result = Suffix(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = ",";
                        var result = this.__MatchString(current, str);
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
                            result = Suffix(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "~";
                        var result = this.__MatchString(current, str);
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
                            result = Suffix(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SPACE
                        /*SKIP SPACE*/ current = _(current).Next;
                    // }}SPACE
                    // {{StringLiteralExpression
                        var str = "^";
                        var result = this.__MatchString(current, str);
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
                            result = Suffix(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{LiftExpression
                    // {{NameExpression
                        var result = Primary(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str = "?";
                            result = this.__MatchString(current, str);
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
            return result;
        }
        
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{LiftExpression
                    // {{NameExpression
                        var result = Primary(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str = "*";
                            result = this.__MatchString(current, str);
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
            return result;
        }
        
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{LiftExpression
                    // {{NameExpression
                        var result = Primary(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
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
                        // {{SPACE
                            /*SKIP SPACE*/ current = _(current).Next;
                        // }}SPACE
                        // {{StringLiteralExpression
                            var str = "+";
                            result = this.__MatchString(current, str);
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
            return result;
        }
        
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{FuseExpression
                    // {{SequenceExpression
                        var nodes = new List<INode>();
                        // {{NameExpression
                            var result = Letter(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes.AddRange(result.Nodes);
                            // {{LiftExpression
                                // {{StarExpression
                                    var start = current;
                                    var nodes2 = new List<INode>();
                                    for (;;)
                                    {
                                        // {{NameExpression
                                            result = LetterOrDigit(current);
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
                                    var nodes3 = new List<INode>();
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
                                        var nodes4 = new List<INode>();
                                        for (;;)
                                        {
                                            // {{SequenceExpression
                                                var nodes5 = new List<INode>();
                                                // {{StringLiteralExpression
                                                    var str = "-";
                                                    result = this.__MatchString(current, str);
                                                // }}StringLiteralExpression
                                                if (result.IsSuccess)
                                                {
                                                    current = result.Next;
                                                    nodes5.AddRange(result.Nodes);
                                                    // {{LiftExpression
                                                        // {{PlusExpression
                                                            var start3 = current;
                                                            var nodes6 = new List<INode>();
                                                            for (;;)
                                                            {
                                                                // {{NameExpression
                                                                    result = LetterOrDigit(current);
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
                                                            var nodes7 = new List<INode>();
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
                                        var nodes8 = new List<INode>();
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
                            var str2 = "_";
                            result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new []{65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122};
                var result = this.__MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return result;
        }
        
        // letter-or-digit -> LetterOrDigit
        public IResult LetterOrDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new []{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122};
                var result = this.__MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return result;
        }
        
        // hex-digit -> HexDigit
        public IResult HexDigit(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new []{48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70,97,98,99,100,101,102};
                var result = this.__MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return result;
        }
        
        // verbatim-string -> VerbatimString
        public IResult VerbatimString(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>();
                    // {{DropExpression
                        // {{StringLiteralExpression
                            var str = "\'";
                            var result = this.__MatchString(current, str);
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
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    // {{NameExpression
                                        result = VerbatimCharacter(current);
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
                                var nodes3 = new List<INode>();
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
                                    var str2 = "\'";
                                    result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // verbatim-character -> VerbatimCharacter
        public IResult VerbatimCharacter(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{NotExpression
                    IResult result;
                    // {{ChoiceExpression
                        // {{StringLiteralExpression
                            var str = "\'";
                            result = this.__MatchString(current, str);
                        // }}StringLiteralExpression
                        if (!result.IsSuccess)
                        {
                            // {{StringLiteralExpression
                                var str2 = "\\";
                                result = this.__MatchString(current, str2);
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = EolChar(current);
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
            return result;
        }
        
        // string -> String
        public IResult String(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{StringLiteralExpression
                        var str = "\'";
                        var result = this.__MatchString(current, str);
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
                            var nodes2 = new List<INode>();
                            for (;;)
                            {
                                // {{LiftExpression
                                    // {{NameExpression
                                        result = Character(current);
                                    // }}NameExpression
                                    if (result.IsSuccess)
                                    {
                                        var nodes3 = new List<INode>();
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
                            var nodes4 = new List<INode>();
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
                                var str2 = "\'";
                                result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // character -> Character
        public IResult Character(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = StringVerbatim(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = Escape(current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        // {{NameExpression
                            result = UnicodeEscape(current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = ByteEscape(current);
                            // }}NameExpression
                        }
                    }
                }
            // }}ChoiceExpression
            return result;
        }
        
        // string-verbatim -> StringVerbatim
        public IResult StringVerbatim(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>();
                    // {{NotExpression
                        IResult result;
                        // {{ChoiceExpression
                            // {{StringLiteralExpression
                                var str = "\'";
                                result = this.__MatchString(current, str);
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{StringLiteralExpression
                                    var str2 = "\\";
                                    result = this.__MatchString(current, str2);
                                // }}StringLiteralExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = EolChar(current);
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
            return result;
        }
        
        // escape -> Escape
        public IResult Escape(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>();
                    // {{DropExpression
                        // {{StringLiteralExpression
                            var str = "\\";
                            var result = this.__MatchString(current, str);
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
                            var values = new []{39,45,48,92,93,97,98,101,102,110,114,116,118};
                            result = this.__MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
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
            return result;
        }
        
        // unicode-escape -> UnicodeEscape
        public IResult UnicodeEscape(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SequenceExpression
                        var nodes2 = new List<INode>();
                        // {{StringLiteralExpression
                            var str = "\\u{";
                            var result = this.__MatchString(current, str);
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes2.AddRange(result.Nodes);
                            // {{NameExpression
                                result = _(current);
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
                        result = UnicodeNumber(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{NameExpression
                                result = _(current);
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
                                    var nodes3 = new List<INode>();
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes4 = new List<INode>();
                                            // {{NameExpression
                                                result = UnicodeNumber(current);
                                            // }}NameExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    // {{NameExpression
                                                        result = _(current);
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
                                    var nodes5 = new List<INode>();
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
                                        var str2 = "}";
                                        result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // unicode-number -> UnicodeNumber
        public IResult UnicodeNumber(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>();
                    // {{NameExpression
                        var result = HexDigit(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{OptionalExpression
                                // {{NameExpression
                                    result = HexDigit(current);
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
                                var nodes2 = new List<INode>();
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
                                        result = HexDigit(current);
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
                                    var nodes3 = new List<INode>();
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
                                            result = HexDigit(current);
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
                                        var nodes4 = new List<INode>();
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
                                                result = HexDigit(current);
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
                                            var nodes5 = new List<INode>();
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
                                                    result = HexDigit(current);
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
                                                var nodes6 = new List<INode>();
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
            return result;
        }
        
        // byte-escape -> ByteEscape
        public IResult ByteEscape(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{SequenceExpression
                        var nodes2 = new List<INode>();
                        // {{StringLiteralExpression
                            var str = "\\x{";
                            var result = this.__MatchString(current, str);
                        // }}StringLiteralExpression
                        if (result.IsSuccess)
                        {
                            current = result.Next;
                            nodes2.AddRange(result.Nodes);
                            // {{NameExpression
                                result = _(current);
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
                        result = ByteNumber(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{DropExpression
                            // {{NameExpression
                                result = _(current);
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
                                    var nodes3 = new List<INode>();
                                    for (;;)
                                    {
                                        // {{SequenceExpression
                                            var nodes4 = new List<INode>();
                                            // {{NameExpression
                                                result = ByteNumber(current);
                                            // }}NameExpression
                                            if (result.IsSuccess)
                                            {
                                                current = result.Next;
                                                nodes4.AddRange(result.Nodes);
                                                // {{DropExpression
                                                    // {{NameExpression
                                                        result = _(current);
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
                                    var nodes5 = new List<INode>();
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
                                        var str2 = "}";
                                        result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // byte-number -> ByteNumber
        public IResult ByteNumber(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{NameExpression
                    var result = HexDigit(current);
                // }}NameExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{LiftExpression
                        // {{OptionalExpression
                            // {{NameExpression
                                result = HexDigit(current);
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
                            var nodes2 = new List<INode>();
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
            return result;
        }
        
        // character-class -> CharacterClass
        public IResult CharacterClass(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{DropExpression
                    // {{StringLiteralExpression
                        var str = "[";
                        var result = this.__MatchString(current, str);
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
                        result = Not(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        current = result.Next;
                        nodes.AddRange(result.Nodes);
                        // {{LiftExpression
                            // {{StarExpression
                                var start = current;
                                var nodes2 = new List<INode>();
                                for (;;)
                                {
                                    // {{LiftExpression
                                        // {{NameExpression
                                            result = ClassPart(current);
                                        // }}NameExpression
                                        if (result.IsSuccess)
                                        {
                                            var nodes3 = new List<INode>();
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
                                var nodes4 = new List<INode>();
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
                                    var str2 = "]";
                                    result = this.__MatchString(current, str2);
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
            return result;
        }
        
        // not -> Not
        public IResult Not(IContext context)
        {
            var current = context;
            // {{LiftExpression
                // {{OptionalExpression
                    // {{StringLiteralExpression
                        var str = "^";
                        var result = this.__MatchString(current, str);
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
                    var nodes = new List<INode>();
                    foreach (var node2 in result.Nodes)
                    {
                        nodes.AddRange(node2.Children);
                    }
                    result = Result.Success(result, result.Next, nodes.ToArray());
                }
            // }}LiftExpression
            return result;
        }
        
        // class-part -> ClassPart
        public IResult ClassPart(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = Range(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{LiftExpression
                        // {{NameExpression
                            result = ClassChar(current);
                        // }}NameExpression
                        if (result.IsSuccess)
                        {
                            var nodes = new List<INode>();
                            foreach (var node in result.Nodes)
                            {
                                nodes.AddRange(node.Children);
                            }
                            result = Result.Success(result, result.Next, nodes.ToArray());
                        }
                    // }}LiftExpression
                }
            // }}ChoiceExpression
            return result;
        }
        
        // range -> Range
        public IResult Range(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{LiftExpression
                    // {{NameExpression
                        var result = ClassChar(current);
                    // }}NameExpression
                    if (result.IsSuccess)
                    {
                        var nodes2 = new List<INode>();
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
                            var str = "-";
                            result = this.__MatchString(current, str);
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
                                result = ClassChar(current);
                            // }}NameExpression
                            if (result.IsSuccess)
                            {
                                var nodes3 = new List<INode>();
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
            return result;
        }
        
        // class-char -> ClassChar
        public IResult ClassChar(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = ClassVerbatim(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = Escape(current);
                    // }}NameExpression
                    if (!result.IsSuccess)
                    {
                        // {{NameExpression
                            result = UnicodeEscape(current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = ByteEscape(current);
                            // }}NameExpression
                        }
                    }
                }
            // }}ChoiceExpression
            return result;
        }
        
        // class-verbatim -> ClassVerbatim
        public IResult ClassVerbatim(IContext context)
        {
            var current = context;
            // {{FuseExpression
                // {{SequenceExpression
                    var nodes = new List<INode>();
                    // {{NotExpression
                        IResult result;
                        // {{ChoiceExpression
                            // {{StringLiteralExpression
                                var str = "]";
                                result = this.__MatchString(current, str);
                            // }}StringLiteralExpression
                            if (!result.IsSuccess)
                            {
                                // {{StringLiteralExpression
                                    var str2 = "\\";
                                    result = this.__MatchString(current, str2);
                                // }}StringLiteralExpression
                                if (!result.IsSuccess)
                                {
                                    // {{NameExpression
                                        result = EolChar(current);
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
            return result;
        }
        
        // _ -> _
        public IResult _(IContext context)
        {
            var current = context;
            // {{StarExpression
                var start = current;
                var nodes = new List<INode>();
                IResult result;
                for (;;)
                {
                    // {{ChoiceExpression
                        // {{NameExpression
                            result = Whitespace(current);
                        // }}NameExpression
                        if (!result.IsSuccess)
                        {
                            // {{NameExpression
                                result = Newline(current);
                            // }}NameExpression
                            if (!result.IsSuccess)
                            {
                                // {{NameExpression
                                    result = Comment(current);
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
            return result;
        }
        
        // comment -> Comment
        public IResult Comment(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{NameExpression
                    var result = SingleLineComment(current);
                // }}NameExpression
                if (!result.IsSuccess)
                {
                    // {{NameExpression
                        result = MultiLineComment(current);
                    // }}NameExpression
                }
            // }}ChoiceExpression
            return result;
        }
        
        // single-line-comment -> SingleLineComment
        public IResult SingleLineComment(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{StringLiteralExpression
                    var str = "//";
                    var result = this.__MatchString(current, str);
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{StarExpression
                        var start = current;
                        var nodes2 = new List<INode>();
                        for (;;)
                        {
                            // {{SequenceExpression
                                var nodes3 = new List<INode>();
                                // {{NotExpression
                                    // {{NameExpression
                                        result = EolChar(current);
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
            return result;
        }
        
        // multi-line-comment -> MultiLineComment
        public IResult MultiLineComment(IContext context)
        {
            var current = context;
            // {{SequenceExpression
                var nodes = new List<INode>();
                // {{StringLiteralExpression
                    var str = "/*";
                    var result = this.__MatchString(current, str);
                // }}StringLiteralExpression
                if (result.IsSuccess)
                {
                    current = result.Next;
                    nodes.AddRange(result.Nodes);
                    // {{StarExpression
                        var start = current;
                        var nodes2 = new List<INode>();
                        for (;;)
                        {
                            // {{SequenceExpression
                                var nodes3 = new List<INode>();
                                // {{NotExpression
                                    // {{StringLiteralExpression
                                        var str2 = "*/";
                                        result = this.__MatchString(current, str2);
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
                            var str3 = "*/";
                            result = this.__MatchString(current, str3);
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
            return result;
        }
        
        // newline -> Newline
        public IResult Newline(IContext context)
        {
            var current = context;
            // {{ChoiceExpression
                // {{StringLiteralExpression
                    var str = "\r\n";
                    var result = this.__MatchString(current, str);
                // }}StringLiteralExpression
                if (!result.IsSuccess)
                {
                    // {{ClassExpression
                        var values = new []{10,13,8232,8233};
                        result = this.__MatchPredicate(current, _current => Array.IndexOf(values, _current) >= 0);
                    // }}ClassExpression
                }
            // }}ChoiceExpression
            return result;
        }
        
        // eol-char -> EolChar
        public IResult EolChar(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new []{10,13,8232,8233};
                var result = this.__MatchPredicate(current, _current => Array.IndexOf(values, _current) >= 0);
            // }}ClassExpression
            return result;
        }
        
        // whitespace -> Whitespace
        public IResult Whitespace(IContext context)
        {
            var current = context;
            // {{ClassExpression
                var values = new []{9,11,12,32,160,5760,6158,8192,8193,8194,8195,8196,8197,8198,8199,8200,8201,8202,8239,8287,12288,65279};
                var result = this.__MatchPredicate(current, _current => Array.BinarySearch(values, _current) >= 0);
            // }}ClassExpression
            return result;
        }
    }
}
