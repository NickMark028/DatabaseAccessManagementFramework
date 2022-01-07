using System;
namespace DatabaseAccessManagement
{
	public class NotEqualToExpression : BinaryOperatorPredicate
	{
		public NotEqualToExpression(string leftMember, string rightMember)
	: base(leftMember, rightMember) { }
		public NotEqualToExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public NotEqualToExpression(string leftMember, Decimal rightMember)
			: base(leftMember, rightMember) { }
		public NotEqualToExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public NotEqualToExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public NotEqualToExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " != " + rightMember;
		}
	}
}
