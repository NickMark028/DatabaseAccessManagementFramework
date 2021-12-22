namespace DatabaseAccessManagement
{
	public class AndPredicate : CompositePredicate
	{
		public AndPredicate(SQLPredicate leftMember, SQLPredicate rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return "(" + leftMember.ToString() + " AND " + rightMember.ToString() + ")";
		}
	}
}