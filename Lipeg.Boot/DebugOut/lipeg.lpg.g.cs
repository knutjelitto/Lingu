#if false
namespace Lipeg.Generated
{
    using Lipeg.Runtime;
    
    public partial class LipegParser
    {
        // start -> Start
        public IResult Start(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            result2 = Grammar(current)
            result2 = Eof(current)
            throw new System.NotImplementedException();
            return result;
        }
        // grammar -> Grammar
        public IResult Grammar(IContext context)
        {
            var result2 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(5);
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            result3 = Identifier(current)
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result2;
        }
        // options -> Options
        public IResult Options(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(4);
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // option -> Option
        public IResult Option(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(4);
            result2 = Identifier(current)
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            result2 = OptionValue(current)
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // option-value -> OptionValue
        public IResult OptionValue(IContext context)
        {
            var result2 = Result.Fail(context);
            result2 = QualifiedIdentifier(current)
            return result2;
        }
        // qualified-identifier -> QualifiedIdentifier
        public IResult QualifiedIdentifier(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            result = Identifier(current)
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // syntax -> Syntax
        public IResult Syntax(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(5);
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // lexical -> Lexical
        public IResult Lexical(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(5);
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // rules -> Rules
        public IResult Rules(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // rule -> Rule
        public IResult Rule(IContext context)
        {
            var result2 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(4);
            result3 = Identifier(current)
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result2;
        }
        // expression -> Expression
        public IResult Expression(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // choice -> Choice
        public IResult Choice(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            result2 = Sequence(current)
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // sequence -> Sequence
        public IResult Sequence(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // prefix -> Prefix
        public IResult Prefix(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // suffix -> Suffix
        public IResult Suffix(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // primary -> Primary
        public IResult Primary(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // inline -> Inline
        public IResult Inline(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(3);
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // any -> Any
        public IResult Any(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            return result2;
        }
        // epsilon -> Epsilon
        public IResult Epsilon(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // eof -> Eof
        public IResult Eof(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // prefix.and -> PrefixAnd
        public IResult PrefixAnd(IContext context)
        {
            var result2 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result2;
        }
        // prefix.not -> PrefixNot
        public IResult PrefixNot(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // prefix.drop -> PrefixDrop
        public IResult PrefixDrop(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // prefix.fuse -> PrefixFuse
        public IResult PrefixFuse(IContext context)
        {
            var result2 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result2;
        }
        // prefix.lift -> PrefixLift
        public IResult PrefixLift(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // suffix.zero-or-one -> SuffixZeroOrOne
        public IResult SuffixZeroOrOne(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // suffix.zero-or-more -> SuffixZeroOrMore
        public IResult SuffixZeroOrMore(IContext context)
        {
            var result2 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result2;
        }
        // suffix.one-or-more -> SuffixOneOrMore
        public IResult SuffixOneOrMore(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // identifier -> Identifier
        public IResult Identifier(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // letter -> Letter
        public IResult Letter(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // letter-or-digit -> LetterOrDigit
        public IResult LetterOrDigit(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // hex-digit -> HexDigit
        public IResult HexDigit(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // verbatim-string -> VerbatimString
        public IResult VerbatimString(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // verbatim-character -> VerbatimCharacter
        public IResult VerbatimCharacter(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // string -> String
        public IResult String(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(3);
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // character -> Character
        public IResult Character(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // string-verbatim -> StringVerbatim
        public IResult StringVerbatim(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // escape -> Escape
        public IResult Escape(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // unicode-escape -> UnicodeEscape
        public IResult UnicodeEscape(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(5);
            var current = context;
            var nodes2 = new List<INode>(2);
            throw new System.NotImplementedException();
            result4 = _(current)
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            result4 = UnicodeNumber(current)
            result2 = _(current)
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result.IsSuccess)
            {
                Result.Success(result, result.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // unicode-number -> UnicodeNumber
        public IResult UnicodeNumber(IContext context)
        {
            var result4 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result4;
        }
        // byte-escape -> ByteEscape
        public IResult ByteEscape(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes2 = new List<INode>(5);
            var current = context;
            var nodes = new List<INode>(2);
            throw new System.NotImplementedException();
            result4 = _(current)
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            result4 = ByteNumber(current)
            result2 = _(current)
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result3.IsSuccess)
            {
                Result.Success(result3, result3.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // byte-number -> ByteNumber
        public IResult ByteNumber(IContext context)
        {
            var result4 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(2);
            result3 = HexDigit(current)
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result4;
        }
        // character-class -> CharacterClass
        public IResult CharacterClass(IContext context)
        {
            var result = Result.Fail(context);
            var current = context;
            var nodes2 = new List<INode>(4);
            throw new System.NotImplementedException();
            if (result2.IsSuccess)
            {
                Result.Success(result2, result2.Next);
            }
            throw new System.NotImplementedException();
            result4 = Not(current)
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result4.IsSuccess)
            {
                Result.Success(result4, result4.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result;
        }
        // not -> Not
        public IResult Not(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // class-part -> ClassPart
        public IResult ClassPart(IContext context)
        {
            var result4 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result4;
        }
        // range -> Range
        public IResult Range(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(3);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            if (result4.IsSuccess)
            {
                Result.Success(result4, result4.Next);
            }
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // class-char -> ClassChar
        public IResult ClassChar(IContext context)
        {
            var result4 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result4;
        }
        // class-verbatim -> ClassVerbatim
        public IResult ClassVerbatim(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // _ -> _
        public IResult _(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // comment -> Comment
        public IResult Comment(IContext context)
        {
            var result3 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result3;
        }
        // single-line-comment -> SingleLineComment
        public IResult SingleLineComment(IContext context)
        {
            var result4 = Result.Fail(context);
            var current = context;
            var nodes2 = new List<INode>(2);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result4;
        }
        // multi-line-comment -> MultiLineComment
        public IResult MultiLineComment(IContext context)
        {
            var result3 = Result.Fail(context);
            var current = context;
            var nodes = new List<INode>(3);
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            throw new System.NotImplementedException();
            return result3;
        }
        // newline -> Newline
        public IResult Newline(IContext context)
        {
            var result2 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result2;
        }
        // eol-char -> EolChar
        public IResult EolChar(IContext context)
        {
            var result = Result.Fail(context);
            throw new System.NotImplementedException();
            return result;
        }
        // whitespace -> Whitespace
        public IResult Whitespace(IContext context)
        {
            var result4 = Result.Fail(context);
            throw new System.NotImplementedException();
            return result4;
        }
    }
}
#endif
