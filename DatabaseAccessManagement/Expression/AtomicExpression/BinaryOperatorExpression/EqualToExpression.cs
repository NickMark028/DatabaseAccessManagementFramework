namespace DatabaseAccessManagement
{
	public class EqualToExpression : BinaryOperatorPredicate
	{
		public EqualToExpression(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " = " + rightMember;
		}
	}
}
