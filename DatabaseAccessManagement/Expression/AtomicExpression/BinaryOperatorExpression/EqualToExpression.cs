using System;
namespace DatabaseAccessManagement
{
	public class EqualToExpression : BinaryOperatorPredicate
	{
		public EqualToExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }
		public EqualToExpression(string leftMember, Int64 rightMember)
			: base(leftMember, rightMember) { }
		public EqualToExpression(string leftMember, Decimal rightMember) 
			: base(leftMember, rightMember) { }
		public EqualToExpression(string leftMember, Double rightMember)
			: base(leftMember, rightMember) { }
		public EqualToExpression(string leftMember, DateTime rightMember)
		: base(leftMember, rightMember) { }
		public EqualToExpression(string leftMember, Boolean rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " = " + rightMember;
		}
	}
}
