namespace DatabaseAccessManagement
{
	public class LessThanOrEqualExpression : BinaryOperatorPredicate
	{
		public LessThanOrEqualExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " <= " + rightMember;
		}
	}
}
