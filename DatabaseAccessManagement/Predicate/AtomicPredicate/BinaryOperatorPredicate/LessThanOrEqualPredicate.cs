namespace DatabaseAccessManagement
{
	public class LessThanOrEqualPredicate : BinaryOperatorPredicate
	{
		public LessThanOrEqualPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " <= " + rightMember;
		}
	}
}
