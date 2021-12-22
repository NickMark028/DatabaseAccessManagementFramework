namespace DatabaseAccessManagement
{
	public class GreaterThanOrEqualPredicate : BinaryOperatorPredicate
	{
		public GreaterThanOrEqualPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " >= " + rightMember;
		}
	}
}
