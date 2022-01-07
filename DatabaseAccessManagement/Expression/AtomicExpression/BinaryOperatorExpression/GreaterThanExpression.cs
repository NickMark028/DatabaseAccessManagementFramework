using System;
namespace DatabaseAccessManagement
{
	public class GreaterThanExpression : BinaryOperatorPredicate
	{
		public GreaterThanExpression(string leftMember, string rightMember)
	: base(leftMember, rightMember) { }
		public GreaterThanExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanExpression(string leftMember, Decimal rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public GreaterThanExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public GreaterThanExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " > " + rightMember;
		}
	}
}
