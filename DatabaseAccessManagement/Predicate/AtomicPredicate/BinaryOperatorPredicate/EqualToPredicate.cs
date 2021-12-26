namespace DatabaseAccessManagement
{
	public class EqualToPredicate : BinaryOperatorPredicate
	{
		public EqualToPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " = " + rightMember;
		}
	}
}
