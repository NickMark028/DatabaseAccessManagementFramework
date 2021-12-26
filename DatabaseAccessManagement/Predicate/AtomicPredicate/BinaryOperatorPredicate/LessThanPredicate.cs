namespace DatabaseAccessManagement
{
	public class LessThanPredicate : BinaryOperatorPredicate
	{
		public LessThanPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " < " + rightMember;
		}
	}
}
