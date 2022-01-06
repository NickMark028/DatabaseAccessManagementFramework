namespace DatabaseAccessManagement
{
	public class GreaterThanExpression : BinaryOperatorPredicate
	{
		public GreaterThanExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " > " + rightMember;
		}
	}
}
