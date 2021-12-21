namespace DatabaseAccessManagement
{
	public abstract class CompositePredicate : SQLPredicate
	{
		protected SQLPredicate leftMember;
		protected SQLPredicate rightMember;

		public CompositePredicate(SQLPredicate leftMember, SQLPredicate rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember;
		}
	}

	public class AndPredicate : CompositePredicate
	{
		public AndPredicate(SQLPredicate leftMember, SQLPredicate rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return "(" + leftMember.ToString() + " AND " + rightMember.ToString() + ")";
		}
	}

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