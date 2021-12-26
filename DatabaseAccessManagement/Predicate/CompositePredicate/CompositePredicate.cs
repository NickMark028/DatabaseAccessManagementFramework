namespace DatabaseAccessManagement
{
	public abstract class CompositePredicate : IPredicate
	{
		protected IPredicate leftPredicate;
		protected IPredicate rightPredicate;

		public CompositePredicate(IPredicate leftPredicate, IPredicate rightPredicate)
		{
			this.leftPredicate = leftPredicate;
			this.rightPredicate = rightPredicate;
		}

		public abstract override string ToString();
	}
}
