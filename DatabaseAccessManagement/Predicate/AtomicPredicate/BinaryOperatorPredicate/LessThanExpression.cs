namespace DatabaseAccessManagement
{
	public class LessThanExpression : BinaryOperatorPredicate
	{
		public LessThanExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " < " + rightMember;
		}
	}
}
