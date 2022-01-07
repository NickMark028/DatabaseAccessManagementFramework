using System;
namespace DatabaseAccessManagement
{
	public class LessThanOrEqualExpression : BinaryOperatorPredicate
	{
		public LessThanOrEqualExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }
		public LessThanOrEqualExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public LessThanOrEqualExpression(string leftMember, Decimal rightMember)
			: base(leftMember, rightMember) { }
		public LessThanOrEqualExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public LessThanOrEqualExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public LessThanOrEqualExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " <= " + rightMember;
		}
	}
}
