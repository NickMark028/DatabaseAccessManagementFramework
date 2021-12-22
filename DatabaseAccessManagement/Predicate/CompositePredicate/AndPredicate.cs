namespace DatabaseAccessManagement
{
	public class AndPredicate : CompositePredicate
	{
		public AndPredicate(IPredicate leftPredicate, IPredicate rightPredicate)
			: base(leftPredicate, rightPredicate) { }

		public override string ToString()
		{
			return "(" + leftPredicate.ToString() + " AND " + rightPredicate.ToString() + ")";
		}
	}
}