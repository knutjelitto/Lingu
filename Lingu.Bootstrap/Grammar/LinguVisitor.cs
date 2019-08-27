using System;
using System.Collections.Generic;
using System.Linq;
using Hime.Redist;

namespace Lingu.Bootstrap
{
    public abstract class LinguVisitor
    {
        protected virtual void VisitNode(ASTNode node)
        {
            VisitNode<bool>(node);
        }

        protected virtual T VisitNode<T>(ASTNode node)
        {
            switch(node.Symbol.ID)
            {
                case 0x0007: return (T)OnTerminalSeparator(node);
                case 0x0009: return (T)OnTerminalName(node);
                case 0x000A: return (T)OnTerminalInteger(node);
                case 0x000C: return (T)OnTerminalLiteralString(node);
                case 0x000D: return (T)OnTerminalLiteralAny(node);
                case 0x000E: return (T)OnTerminalLiteralText(node);
                case 0x000F: return (T)OnTerminalLiteralClass(node);
                case 0x0010: return (T)OnTerminalUnicodeBlock(node);
                case 0x0011: return (T)OnTerminalUnicodeCategory(node);
                case 0x0012: return (T)OnTerminalUnicodeCodepoint(node);
                case 0x0013: return (T)OnTerminalUnicodeSpanMarker(node);
                case 0x0014: return (T)OnTerminalOperatorOptional(node);
                case 0x0015: return (T)OnTerminalOperatorZeromore(node);
                case 0x0016: return (T)OnTerminalOperatorOnemore(node);
                case 0x0017: return (T)OnTerminalOperatorUnion(node);
                case 0x0018: return (T)OnTerminalOperatorDifference(node);
                case 0x0019: return (T)OnTerminalTreeActionPromote(node);
                case 0x001A: return (T)OnTerminalTreeActionDrop(node);
                case 0x001B: return (T)OnVariableFile(node);
                case 0x001C: return (T)OnVariableCfGrammar(node);
                case 0x001D: return (T)OnVariableGrammarOptions(node);
                case 0x001E: return (T)OnVariableOption(node);
                case 0x001F: return (T)OnVariableGrammarTerminals(node);
                case 0x0020: return (T)OnVariableTerminalItem(node);
                case 0x0021: return (T)OnVariableTerminalRule(node);
                case 0x0022: return (T)OnVariableTerminalFragment(node);
                case 0x0023: return (T)OnVariableTerminalContext(node);
                case 0x0024: return (T)OnVariableTerminalDefinition(node);
                case 0x0025: return (T)OnVariableTerminalDefRestrict(node);
                case 0x0026: return (T)OnVariableTerminalDefFragment(node);
                case 0x0027: return (T)OnVariableTerminalDefRepetition(node);
                case 0x0028: return (T)OnVariableTerminalDefElement(node);
                case 0x0029: return (T)OnVariableTerminalDefAtom(node);
                case 0x002A: return (T)OnVariableTerminalDefCardinalilty(node);
                case 0x002B: return (T)OnVariableGrammarRules(node);
                case 0x002C: return (T)OnVariableRule(node);
                case 0x002D: return (T)OnVariableRuleSimple(node);
                case 0x002E: return (T)OnVariableRuleTemplate(node);
                case 0x002F: return (T)OnVariableRuleDefinition(node);
                case 0x0030: return (T)OnVariableRuleDefChoice(node);
                case 0x0031: return (T)OnVariableRuleDefFragment(node);
                case 0x0032: return (T)OnVariableRuleDefRepetition(node);
                case 0x0033: return (T)OnVariableRuleDefTreeAction(node);
                case 0x0034: return (T)OnVariableRuleDefElement(node);
                case 0x0035: return (T)OnVariableRuleDefAtom(node);
                case 0x0036: return (T)OnVariableRuleDefContext(node);
                case 0x0037: return (T)OnVariableRuleDefSub(node);
                case 0x0038: return (T)OnVariableRuleSymAction(node);
                case 0x0039: return (T)OnVariableRuleSymVirtual(node);
                case 0x003A: return (T)OnVariableRuleSymRefSimple(node);
                case 0x003B: return (T)OnVariableRuleSymRefTemplate(node);
                case 0x003C: return (T)OnVariableRuleSymRefParams(node);
                case 0x003D: return (T)OnVariableRuleTemplateParams(node);
                case 0x004D: return (T)OnVirtualConcat(node);
                case 0x0051: return (T)OnVirtualRange(node);
                case 0x0056: return (T)OnVirtualEmptypart(node);
                default:
                    throw new NotImplementedException();
            }
        }

        protected virtual IEnumerable<object> VisitChildren(ASTNode node)
        {
            foreach (var child in node.Children)
            {
                yield return VisitNode<object>(child);
            }

        }

        protected virtual IEnumerable<T> VisitChildren<T>(ASTNode node)
        {
            foreach (var child in node.Children)
            {
                yield return VisitNode<T>(child);
            }

        }

        protected virtual object OnTerminalSeparator(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalName(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalInteger(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalLiteralString(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalLiteralAny(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalLiteralText(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalLiteralClass(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalUnicodeBlock(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalUnicodeCategory(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalUnicodeCodepoint(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalUnicodeSpanMarker(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalOperatorOptional(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalOperatorZeromore(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalOperatorOnemore(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalOperatorUnion(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalOperatorDifference(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalTreeActionPromote(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnTerminalTreeActionDrop(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableFile(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableCfGrammar(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableGrammarOptions(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableOption(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableGrammarTerminals(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalItem(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalRule(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalFragment(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalContext(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefinition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefRestrict(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefFragment(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefRepetition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefElement(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefAtom(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableTerminalDefCardinalilty(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableGrammarRules(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRule(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSimple(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleTemplate(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefinition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefChoice(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefFragment(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefRepetition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefTreeAction(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefElement(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefAtom(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefContext(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleDefSub(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSymAction(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSymVirtual(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSymRefSimple(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSymRefTemplate(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleSymRefParams(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVariableRuleTemplateParams(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVirtualConcat(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVirtualRange(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        protected virtual object OnVirtualEmptypart(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }
        partial class OnTerminal
        {
            protected OnTerminal(LinguVisitor visitor)
            {
            }
        }
        
        partial class OnVariable
        {
        }
        
        partial class OnVirtual
        {
        }
    }
}
