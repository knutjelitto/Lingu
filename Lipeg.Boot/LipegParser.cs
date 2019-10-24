using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pegasus.Common;
using Pegasus.Parser;

namespace Lipeg.Boot
{
    public partial class LipegParser
    {
        internal readonly CSharpParser cSharpParser = new CSharpParser();

        protected INode N(string name, params INode[] children)
        {
            return children.Length == 0 ? LeafNode.From(name) : InternalNode.From(name, children);
        }

        protected INode N(Cursor start, Cursor end, string name, params INode[] children)
        {
            return children.Length == 0 ? LeafNode.From(name) : InternalNode.From(name, children);
        }

        protected INode N(Cursor start, Cursor end, string name, string value)
        {
            return LeafNode.From(name);
        }

        protected INode NP(IList<INode> children)
        {
            return InternalNode.From("+", children.ToArray());
        }

        protected string NP(IList<string> children)
        {
            return String.Join(String.Empty, children);
        }

        protected INode NS(IList<INode> children)
        {
            return InternalNode.From("*", children.ToArray());
        }

        protected INode NO(IList<INode> children)
        {
            return InternalNode.From("?", children.ToArray());
        }

        protected String NO(IList<String> children)
        {
            return children.FirstOrDefault() ?? String.Empty;
        }

        protected Grammar Grammar(IList<Setting> settings, IList<Rule> rules)
        {
            return SDK.Tree.Grammar.From(settings.ToList().AsReadOnly(), rules.ToList().AsReadOnly());
        }

        protected Setting Setting(Identifier identifier, object value)
        {
            return SDK.Tree.Setting.From(identifier, value);
        }

        protected Rule Rule(Identifier identifier, IList<CodeSpan> type, IList<Identifier> flags, Expression expression)
        {
            var typeValue = type.SingleOrDefault();
            return SDK.Tree.Rule.From(
                identifier,
                typeValue != null ? TypedExpression.From(typeValue, expression) : expression,
                flags);
        }

        protected Expression Choice(IList<Expression> choices)
        {
            return choices.Count == 1 ? choices[0] : ChoiceExpression.From(choices);
        }

        protected Expression Sequence(IList<Expression> sequence, Expression? code = null)
        {
            if (code != null)
            {
                return SequenceExpression.From(sequence.Concat(Enumerable.Repeat(code, 1)));
            }

            return sequence.Count == 1 ? sequence[0] : SequenceExpression.From(sequence);
        }

        protected PrefixedExpression Prefixed(Identifier identifier, Expression expression)
        {
            return PrefixedExpression.From(identifier, expression);
        }

        protected AndCodeExpression AndCode(CodeSpan codeSpan)
        {
            return AndCodeExpression.From(codeSpan);
        }

        protected NotCodeExpression NotCode(CodeSpan codeSpan)
        {
            return NotCodeExpression.From(codeSpan);
        }

        protected AndExpression And(Expression expression)
        {
            return AndExpression.From(expression);
        }

        protected NotExpression Not(Expression expression)
        {
            return NotExpression.From(expression);
        }

        protected RepetitionExpression Repetition(Expression expression, Quantifier quantifier)
        {
            return RepetitionExpression.From(expression, quantifier);
        }

        protected Expression Typed(IList<CodeSpan> type, Expression expression)
        {
            var typeValue = type.SingleOrDefault();
            return typeValue != null ? TypedExpression.From(typeValue, expression) : expression;
        }

        protected NameExpression Name(Identifier identifier)
        {
            return NameExpression.From(identifier);
        }

        protected WildcardExpression Wildcard()
        {
            return WildcardExpression.From();
        }

        private ILocation Loc(Cursor start, Cursor end)
        {
            return Location.From(start, end);
        }

        protected Quantifier Quantifier(Cursor start, Cursor end, int min, int? max, Expression? delimiter = null)
        {
            return SDK.Tree.Quantifier.From(Loc(start, end), min, max, delimiter);
        }

        protected Quantifier Quantifier(Cursor start, Cursor end, int min)
        {
            return SDK.Tree.Quantifier.From(Loc(start, end), min, null);
        }

        protected Quantifier Quantifier(Cursor start, Cursor end, int min, IList<int> max, Expression? delimiter = null)
        {
            return SDK.Tree.Quantifier.From(Loc(start, end), min, max.SingleOrDefault(), delimiter);
        }

        protected int Int(string digits)
        {
            return int.Parse(digits);
        }

        protected CodeExpression CodeError(CodeSpan codeSpan)
        {
            return CodeExpression.From(codeSpan, CodeType.Error);
        }

        protected CodeExpression CodeParse(CodeSpan codeSpan)
        {
            return CodeExpression.From(codeSpan, CodeType.Parse);
        }

        protected CodeExpression CodeState(CodeSpan codeSpan)
        {
            return CodeExpression.From(codeSpan, CodeType.State);
        }

        protected CodeExpression CodeResult(CodeSpan codeSpan)
        {
            return CodeExpression.From(codeSpan, CodeType.Result);
        }

        protected CodeSpan Span(CSharpSyntaxNode syntax, Cursor start, Cursor end)
        {
            return Span(syntax.ToFullString(), start, end);
        }

        protected CodeSpan Span(string text, Cursor start, Cursor end)
        {
            return CodeSpan.From(Loc(start, end), text);
        }

        protected CodeSpan Span(TypeSyntax type, Cursor start, Cursor end)
        {
            var value = Regex.Replace(Regex.Replace(type.ToString(), @"(?<!,)\s+|\s+(?=[,\]])", ""), @",(?=\w)", ", ");
            return CodeSpan.From(Loc(start, end), type.ToFullString(), value);
        }

        protected string Concat(IList<string> strings)
        {
            return string.Concat(strings);
        }

        protected bool IsBlock(StatementSyntax maybeBlock)
        {
            return maybeBlock is BlockSyntax;
        }

        protected BlockSyntax AsBlock(StatementSyntax block)
        {
            return (BlockSyntax)block;
        }

        protected Identifier Identifier(string name, Cursor start, Cursor end)
        {
            return SDK.Tree.Identifier.From(Loc(start, end), name);
        }

        protected T Error<T>()
        {
            throw new InvalidOperationException();
        }

        protected CharacterRange Range(string begin, string end)
        {
            return CharacterRange.From(begin[0], end[0]);
        }

        protected string SimpleEsc(string c)
        {
            Debug.Assert(c.Length == 1);

            return c
                .Replace("0", "\0")
                .Replace("a", "\a")
                .Replace("b", "\b")
                .Replace("f", "\f")
                .Replace("n", "\n")
                .Replace("r", "\r")
                .Replace("t", "\t")
                .Replace("v", "\v");
        }

        protected string HexChar(string hexDigits)
        {
            return ((char)int.Parse(hexDigits, NumberStyles.HexNumber)).ToString();
        }

        protected LiteralExpression Literal(Cursor start, Cursor end, string value)
        {
            return LiteralExpression.From(Loc(start, end), value);
        }

        protected ClassExpression Class(IList<CharacterRange> ranges, IList<string> inverted)
        {
            return ClassExpression.From(ranges, inverted.SingleOrDefault() == "^");
        }
    }
}
