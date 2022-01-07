using System;
namespace DatabaseAccessManagement
{
	public class LessThanExpression : BinaryOperatorPredicate
	{
		public LessThanExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }
		public LessThanExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public LessThanExpression(string leftMember, Decimal rightMember)
			: base(leftMember, rightMember) { }
		public LessThanExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public LessThanExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public LessThanExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " < " + rightMember;
		}
	}
}
