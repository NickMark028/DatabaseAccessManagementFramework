namespace DatabaseAccessManagement
{
	public class GreaterThanOrEqualExpression : BinaryOperatorPredicate
	{
		public GreaterThanOrEqualExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " >= " + rightMember;
		}
	}
}
