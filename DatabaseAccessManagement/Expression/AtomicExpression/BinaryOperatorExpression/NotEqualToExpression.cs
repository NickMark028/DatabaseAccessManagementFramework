namespace DatabaseAccessManagement
{
	public class NotEqualToExpression : BinaryOperatorPredicate
	{
		public NotEqualToExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " != " + rightMember;
		}
	}
}
