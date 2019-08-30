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
                case 0x0007: return (T)OnTerminalBlockComment(node);
                case 0x0008: return (T)OnTerminalSeparator(node);
                case 0x000A: return (T)OnTerminalName(node);
                case 0x000B: return (T)OnTerminalInteger(node);
                case 0x000D: return (T)OnTerminalLiteralString(node);
                case 0x000E: return (T)OnTerminalLiteralAny(node);
                case 0x000F: return (T)OnTerminalLiteralText(node);
                case 0x0010: return (T)OnTerminalLiteralClass(node);
                case 0x0011: return (T)OnTerminalUnicodeBlock(node);
                case 0x0012: return (T)OnTerminalUnicodeCategory(node);
                case 0x0013: return (T)OnTerminalUnicodeCodepoint(node);
                case 0x0014: return (T)OnVariableFile(node);
                case 0x0015: return (T)OnVariableCfGrammar(node);
                case 0x0016: return (T)OnVariableGrammarOptions(node);
                case 0x0017: return (T)OnVariableOption(node);
                case 0x0018: return (T)OnVariableGrammarTerminals(node);
                case 0x0019: return (T)OnVariableTerminalRule(node);
                case 0x001A: return (T)OnVariableTerminalDefinition(node);
                case 0x001B: return (T)OnVariableTerminalDifference(node);
                case 0x001C: return (T)OnVariableTerminalSequence(node);
                case 0x001D: return (T)OnVariableTerminalRepetition(node);
                case 0x001E: return (T)OnVariableTerminalElement(node);
                case 0x001F: return (T)OnVariableTerminalNot(node);
                case 0x0020: return (T)OnVariableTerminalAtom(node);
                case 0x0021: return (T)OnVariableTerminalRange(node);
                case 0x0022: return (T)OnVariableCharacter(node);
                case 0x0023: return (T)OnVariableTerminalText(node);
                case 0x0024: return (T)OnVariableTerminalCardinalilty(node);
                case 0x0025: return (T)OnVariableGrammarRules(node);
                case 0x0026: return (T)OnVariableRule(node);
                case 0x0027: return (T)OnVariableRuleDefinition(node);
                case 0x0028: return (T)OnVariableRuleAlternative(node);
                case 0x0029: return (T)OnVariableRuleSequence(node);
                case 0x002A: return (T)OnVariableRuleRepetition(node);
                case 0x002B: return (T)OnVariableRuleTreeAction(node);
                case 0x002C: return (T)OnVariableRuleElement(node);
                case 0x002D: return (T)OnVariableRuleSub(node);
                case 0x002E: return (T)OnVariableRuleAtom(node);
                case 0x002F: return (T)OnVariableRuleText(node);
                case 0x0030: return (T)OnVariableRuleAction(node);
                case 0x0031: return (T)OnVariableRuleVirtual(node);
                case 0x0032: return (T)OnVariableRuleRef(node);
                case 0x0049: return (T)OnVirtualRange(node);
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

        protected virtual object OnTerminalBlockComment(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
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

        protected virtual object OnVariableTerminalRule(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalDefinition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalDifference(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalSequence(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalRepetition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalElement(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalNot(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalAtom(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalRange(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableCharacter(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalText(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableTerminalCardinalilty(ASTNode node)
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

        protected virtual object OnVariableRuleDefinition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleAlternative(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleSequence(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleRepetition(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleTreeAction(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleElement(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleSub(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleAtom(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleText(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleAction(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleVirtual(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVariableRuleRef(ASTNode node)
        {
            return VisitChildren(node).FirstOrDefault();
        }

        protected virtual object OnVirtualRange(ASTNode node)
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

