namespace DatabaseAccessManagement
{
	public class OrPredicate : CompositePredicate
	{
		public OrPredicate(IPredicate leftPredicate, IPredicate rightPredicate)
			: base(leftPredicate, rightPredicate) { }

		public override string ToString()
		{
			return "(" + leftPredicate.ToString() + " OR " + rightPredicate.ToString() + ")";
		}
	}
}