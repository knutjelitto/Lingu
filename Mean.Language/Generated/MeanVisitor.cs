using System;
using System.Collections.Generic;
using System.Linq;
using Hime.Redist;

namespace Mean.Language.Generated
{
	public abstract class MeanVisitor
	{
		protected virtual void VisitNode(ASTNode node)
		{
			VisitNode<bool>(node);
		}

		protected virtual T VisitNode<T>(ASTNode node)
		{
			switch(node.Symbol.ID)
			{
				case 0x0003: return (T)OnTerminalIdentifier(node);
				case 0x0016: return (T)OnTerminalSeparator(node);
				case 0x0017: return (T)OnTerminalIntegerLiteral(node);
				case 0x0018: return (T)OnTerminalFloatLiteral(node);
				case 0x0019: return (T)OnTerminalBoolLiteral(node);
				case 0x0004: return (T)OnVariableIdentifier(node);
				case 0x0005: return (T)OnVariableType(node);
				case 0x005C: return (T)OnVariableTupleIndex(node);
				case 0x005D: return (T)OnVariableLiteral(node);
				case 0x005E: return (T)OnVariableName(node);
				case 0x005F: return (T)OnVariableGenericArgs(node);
				case 0x0060: return (T)OnVariableGenericArgsTypes(node);
				case 0x0061: return (T)OnVariableGenericArgsBindings(node);
				case 0x0062: return (T)OnVariableGenericArgsBinding(node);
				case 0x0063: return (T)OnVariableListNameT0001(node);
				case 0x0065: return (T)OnVariableListGenericArgsBindingT0001(node);
				case 0x0067: return (T)OnVariablePrimaryExpression(node);
				case 0x0068: return (T)OnVariablePostfixExpression(node);
				case 0x0069: return (T)OnVariableUnaryExpression(node);
				case 0x006A: return (T)OnVariableMulExpression(node);
				case 0x006B: return (T)OnVariableAddExpression(node);
				case 0x006C: return (T)OnVariableShiftExpression(node);
				case 0x006D: return (T)OnVariableEqualityExpression(node);
				case 0x006E: return (T)OnVariableBitAndExpression(node);
				case 0x006F: return (T)OnVariableBitXorExpression(node);
				case 0x0070: return (T)OnVariableBitOrExpression(node);
				case 0x0071: return (T)OnVariableAndExpression(node);
				case 0x0072: return (T)OnVariableOrExpression(node);
				case 0x0073: return (T)OnVariableConditionalExpression(node);
				case 0x0074: return (T)OnVariableWithoutBlockExpression(node);
				case 0x0075: return (T)OnVariableExpression(node);
				case 0x0076: return (T)OnVariableWithBlockExpression(node);
				case 0x0077: return (T)OnVariableBlockExpression(node);
				case 0x0078: return (T)OnVariableSloppyListExpressionT0001(node);
				case 0x007A: return (T)OnVariableUnit(node);
				case 0x007B: return (T)OnVariableUnitItem(node);
				case 0x007C: return (T)OnVariableNamespace(node);
				case 0x007D: return (T)OnVariableNamespaceItems(node);
				case 0x007E: return (T)OnVariableNamespaceItem(node);
				case 0x007F: return (T)OnVariableDefinedFunction(node);
				case 0x0080: return (T)OnVariableDeclaredFunction(node);
				case 0x0081: return (T)OnVariableDefinedMethod(node);
				case 0x0082: return (T)OnVariableDeclaredMethod(node);
				case 0x0083: return (T)OnVariableFunctionKernel(node);
				case 0x0084: return (T)OnVariableMaybeFunParameters(node);
				case 0x0085: return (T)OnVariableFunParameter(node);
				case 0x0086: return (T)OnVariableMaybeFunctionItems(node);
				case 0x0087: return (T)OnVariableFunctionItem(node);
				case 0x0088: return (T)OnVariableTypeAlias(node);
				case 0x0089: return (T)OnVariableTrait(node);
				case 0x008A: return (T)OnVariableMaybeTraitItems(node);
				case 0x008B: return (T)OnVariableTraitItem(node);
				case 0x008C: return (T)OnVariableTraitOutputType(node);
				case 0x008D: return (T)OnVariableMaybeTypeAnnotation(node);
				case 0x008E: return (T)OnVariableTypeAnnotation(node);
				case 0x008F: return (T)OnVariableMaybeGenericParameters(node);
				case 0x0090: return (T)OnVariableGenericParameters(node);
				case 0x0091: return (T)OnVariableGenericNames(node);
				case 0x0092: return (T)OnVariableGenericName(node);
				case 0x0093: return (T)OnVariableGenericDefaults(node);
				case 0x0094: return (T)OnVariableGenericDefault(node);
				case 0x0095: return (T)OnVariableMaybeWhere(node);
				case 0x0096: return (T)OnVariableWhere(node);
				case 0x0039: return (T)OnVirtualFlist(node);
				case 0x003A: return (T)OnVirtualIselect(node);
				case 0x003B: return (T)OnVirtualTselect(node);
				case 0x003C: return (T)OnVirtualMselect(node);
				case 0x003D: return (T)OnVirtualNegOp(node);
				case 0x003E: return (T)OnVirtualPosOp(node);
				case 0x003F: return (T)OnVirtualNotOp(node);
				case 0x0040: return (T)OnVirtualMulOp(node);
				case 0x0041: return (T)OnVirtualDivOp(node);
				case 0x0042: return (T)OnVirtualRemOp(node);
				case 0x0043: return (T)OnVirtualModOp(node);
				case 0x0044: return (T)OnVirtualAddOp(node);
				case 0x0045: return (T)OnVirtualSubOp(node);
				case 0x0046: return (T)OnVirtualShlOp(node);
				case 0x0047: return (T)OnVirtualShrOp(node);
				case 0x0048: return (T)OnVirtualEqOp(node);
				case 0x0049: return (T)OnVirtualNeOp(node);
				case 0x004A: return (T)OnVirtualLtOp(node);
				case 0x004B: return (T)OnVirtualLtleOp(node);
				case 0x004C: return (T)OnVirtualLtltOp(node);
				case 0x004D: return (T)OnVirtualLeOp(node);
				case 0x004E: return (T)OnVirtualLeleOp(node);
				case 0x004F: return (T)OnVirtualLeltOp(node);
				case 0x0050: return (T)OnVirtualGtOp(node);
				case 0x0051: return (T)OnVirtualGtgeOp(node);
				case 0x0052: return (T)OnVirtualGtgtOp(node);
				case 0x0053: return (T)OnVirtualGeOp(node);
				case 0x0054: return (T)OnVirtualGegeOp(node);
				case 0x0055: return (T)OnVirtualGegtOp(node);
				case 0x0056: return (T)OnVirtualAndOp(node);
				case 0x0057: return (T)OnVirtualXorOp(node);
				case 0x0058: return (T)OnVirtualOrOp(node);
				case 0x0059: return (T)OnVirtualAndThenOp(node);
				case 0x005A: return (T)OnVirtualOrElseOp(node);
				case 0x005B: return (T)OnVirtualIff(node);
				default:
					throw new NotImplementedException();
			}
		}

		protected virtual IEnumerable<object> VisitChildren(ASTNode node)
		{
			for (var i = 0; i < node.Children.Count; i++)
			{
				yield return VisitNode<object>(node.Children[i]);
			}
		}
		protected virtual IEnumerable<T> VisitChildren<T>(ASTNode node)
		{
			for (var i = 0; i < node.Children.Count; i++)
			{
				yield return VisitNode<T>(node.Children[i]);
			}
		}

		public virtual object OnTerminalIdentifier(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnTerminalSeparator(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnTerminalIntegerLiteral(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnTerminalFloatLiteral(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnTerminalBoolLiteral(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableIdentifier(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableType(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTupleIndex(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableLiteral(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableName(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericArgs(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericArgsTypes(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericArgsBindings(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericArgsBinding(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableListNameT0001(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableListGenericArgsBindingT0001(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariablePrimaryExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariablePostfixExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableUnaryExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMulExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableAddExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableShiftExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableEqualityExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableBitAndExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableBitXorExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableBitOrExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableAndExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableOrExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableConditionalExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableWithoutBlockExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableWithBlockExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableBlockExpression(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableSloppyListExpressionT0001(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableUnit(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableUnitItem(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableNamespace(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableNamespaceItems(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableNamespaceItem(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableDefinedFunction(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableDeclaredFunction(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableDefinedMethod(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableDeclaredMethod(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableFunctionKernel(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeFunParameters(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableFunParameter(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeFunctionItems(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableFunctionItem(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTypeAlias(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTrait(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeTraitItems(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTraitItem(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTraitOutputType(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeTypeAnnotation(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableTypeAnnotation(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeGenericParameters(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericParameters(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericNames(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericName(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericDefaults(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableGenericDefault(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableMaybeWhere(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVariableWhere(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualFlist(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualIselect(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualTselect(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualMselect(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualNegOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualPosOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualNotOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualMulOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualDivOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualRemOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualModOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualAddOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualSubOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualShlOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualShrOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualEqOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualNeOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLtOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLtleOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLtltOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLeOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLeleOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualLeltOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGtOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGtgeOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGtgtOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGeOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGegeOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualGegtOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualAndOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualXorOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualOrOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualAndThenOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualOrElseOp(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
		public virtual object OnVirtualIff(ASTNode node)
		{
			return VisitChildren(node).FirstOrDefault();
		}
	}
}
