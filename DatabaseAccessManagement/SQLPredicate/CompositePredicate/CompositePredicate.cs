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
}
