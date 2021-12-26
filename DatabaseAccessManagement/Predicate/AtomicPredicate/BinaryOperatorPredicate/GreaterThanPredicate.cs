namespace DatabaseAccessManagement
{
	public class GreaterThanPredicate : BinaryOperatorPredicate
	{
		public GreaterThanPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " > " + rightMember;
		}
	}
}
