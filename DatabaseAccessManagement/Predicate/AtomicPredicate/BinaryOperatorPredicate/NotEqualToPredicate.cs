namespace DatabaseAccessManagement
{
	public class NotEqualToPredicate : BinaryOperatorPredicate
	{
		public NotEqualToPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " != " + rightMember;
		}
	}
}
