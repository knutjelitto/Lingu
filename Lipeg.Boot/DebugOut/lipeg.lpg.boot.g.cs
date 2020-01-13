namespace Lipeg.Generated
{
    using System;
    using System.Collections.Generic;
    using Lipeg.SDK.Parsers;
    using Lipeg.SDK.Tree;
    using Lipeg.Runtime;
    
    public partial class LipegParser
    {
        // start -> Start
        public IResult Start(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            // SequenceExpression:
            var nodes = new List<INode>(2);
            // NameExpression:
            var result2 = Grammar(current);
            if (result2.IsSuccess)
            {
                nodes.AddRange(result2.Nodes);
                current = result2.Next;
                // NameExpression:
                result2 = Eof(current);
                if (result2.IsSuccess)
                {
                    nodes.AddRange(result2.Nodes);
                    current = result2.Next;
                    result2 = Result.Success(nodes[0], current, nodes.ToArray());
                }
            }
            return result;
        }
        
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            // SequenceExpression:
            var nodes = new List<INode>(5);
            // DropExpression:
            // StringLiteralExpression:
            var str = "grammar";
            IResult result2;
            if (current.StartsWith(str))
            {
                var next = current.Advance(str.Length);
                var location = Location.From(current, next);
                var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                result2 = Result.Success(location, next, node);
                current = next;
            }
            else
            {
                result2 = Result.Fail(current);
            }
            if (result2.IsSuccess)
            {
                result2 = Result.Success(result2, result2.Next);
            }
            if (result2.IsSuccess)
            {
                nodes.AddRange(result2.Nodes);
                current = result2.Next;
                // NameExpression:
                result2 = Identifier(current);
                if (result2.IsSuccess)
                {
                    nodes.AddRange(result2.Nodes);
                    current = result2.Next;
                    // DropExpression:
                    // StringLiteralExpression:
                    var str2 = "{";
                    if (current.StartsWith(str2))
                    {
                        var next2 = current.Advance(str2.Length);
                        var location2 = Location.From(current, next2);
                        var node2 = Leaf.From(location2, NodeSymbols.StringLiteral, str2);
                        result2 = Result.Success(location2, next2, node2);
                        current = next2;
                    }
                    else
                    {
                        result2 = Result.Fail(current);
                    }
                    if (result2.IsSuccess)
                    {
                        result2 = Result.Success(result2, result2.Next);
                    }
                    if (result2.IsSuccess)
                    {
                        nodes.AddRange(result2.Nodes);
                        current = result2.Next;
                        // LiftExpression:
                        // StarExpression:
                        var start = current;
                        var nodes2 = new List<INode>();
                        for (;;)
                        {
                            // ChoiceExpression:
                            // NameExpression:
                            result2 = Options(current);
                            if (!result2.IsSuccess)
                            {
                                // NameExpression:
                                result2 = Syntax(current);
                                if (!result2.IsSuccess)
                                {
                                    // NameExpression:
                                    result2 = Lexical(current);
                                }
                            }
                            if (result2.IsSuccess)
                            {
                                nodes2.AddRange(result2.Nodes);
                                current = result2.Next;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var location3 = Location.From(start, current);
                        var node3 = NodeList.From(location3, NodeSymbols.Star, nodes2);
                        result2 = Result.Success(location3, current, node3);
                        if (result2.IsSuccess)
                        {
                            var nodes3 = new List<INode>();
                            foreach (var node4 in result2.Nodes)
                            {
                                nodes3.AddRange(node4.Children);
                            }
                            result2 = Result.Success(result2, result2.Next, nodes3.ToArray());
                        }
                        if (result2.IsSuccess)
                        {
                            nodes.AddRange(result2.Nodes);
                            current = result2.Next;
                            // DropExpression:
                            // StringLiteralExpression:
                            var str3 = "}";
                            if (current.StartsWith(str3))
                            {
                                var next3 = current.Advance(str3.Length);
                                var location4 = Location.From(current, next3);
                                var node5 = Leaf.From(location4, NodeSymbols.StringLiteral, str3);
                                result2 = Result.Success(location4, next3, node5);
                                current = next3;
                            }
                            else
                            {
                                result2 = Result.Fail(current);
                            }
                            if (result2.IsSuccess)
                            {
                                result2 = Result.Success(result2, result2.Next);
                            }
                            if (result2.IsSuccess)
                            {
                                nodes.AddRange(result2.Nodes);
                                current = result2.Next;
                                result2 = Result.Success(nodes[0], current, nodes.ToArray());
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
            throw new NotImplementedException();
        }
        
        // option -> Option
        public IResult Option(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix -> Prefix
        public IResult Prefix(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // suffix -> Suffix
        public IResult Suffix(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // any -> Any
        public IResult Any(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            throw new NotImplementedException();
        }
        
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            throw new NotImplementedException();
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
