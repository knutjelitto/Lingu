using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lipeg.Boot.Tree;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pegasus.Common;

namespace Lipeg.Boot
{
    public partial class LipegParser
    {
        protected Grammar Grammar(IEnumerable<Rule> rules, IEnumerable<Setting> settings, Cursor end)
        {
            return Tree.Grammar.From(rules, settings, end);
        }

        protected Setting Setting(Identifier identifier, object value)
        {
            return Tree.Setting.From(identifier, value);
        }

        protected Rule Rule(Identifier identifier, IList<CodeSpan> type, IList<Identifier> flags, Expression expression)
        {
            var typeValue = type.SingleOrDefault();
            return Tree.Rule.From(
                identifier,
                typeValue != null ? TypedExpression.From(typeValue, expression) : expression,
                flags);
        }

        protected Expression Choice(IList<Expression> choices)
        {
            return choices.Count == 1 ? choices[0] : ChoiceExpression.From(choices);
        }

        protected Expression Sequence(IList<Expression> sequence, CodeExpression? code = null)
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

        protected Quantifier Quantifier(Cursor start, Cursor end, int min, int? max, Expression? delimiter = null)
        {
            return Tree.Quantifier.From(start, end, min, max, delimiter);
        }

        protected int Int(string digits)
        {
            return Int32.Parse(digits);
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

        protected CodeSpan Span(string text, Cursor start, Cursor end)
        {
            return CodeSpan.From(text, start, end);
        }

        protected CodeSpan Span(TypeSyntax type, Cursor start, Cursor end)
        {
            var value = Regex.Replace(Regex.Replace(type.ToString(), @"(?<!,)\s+|\s+(?=[,\]])", ""), @",(?=\w)", ", ");
            return CodeSpan.From(type.ToFullString(), start, end, value);
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
            return Tree.Identifier.From(name, start, end);
        }

        protected T Error<T>()
        {
            throw new InvalidOperationException();
        }

        protected void Error(string resourceKey, params object[] parameters)
        {

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
    }
}
