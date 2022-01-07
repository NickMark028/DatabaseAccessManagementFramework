using System;
namespace DatabaseAccessManagement
{
	public class GreaterThanOrEqualExpression : BinaryOperatorPredicate
	{
		public GreaterThanOrEqualExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanOrEqualExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanOrEqualExpression(string leftMember, Decimal rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanOrEqualExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanOrEqualExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public GreaterThanOrEqualExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " >= " + rightMember;
		}
	}
}
