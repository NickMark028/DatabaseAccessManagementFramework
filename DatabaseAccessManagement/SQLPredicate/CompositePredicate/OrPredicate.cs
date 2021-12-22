namespace DatabaseAccessManagement
{
	public class OrPredicate : CompositePredicate
	{
		public OrPredicate(SQLPredicate leftMember, SQLPredicate rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return "(" + leftMember.ToString() + " OR " + rightMember.ToString() + ")";
		}
	}
}