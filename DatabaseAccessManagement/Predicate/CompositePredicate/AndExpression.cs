namespace DatabaseAccessManagement
{
	public class AndExpression : CompositeExpression
	{
		public AndExpression(IExpression leftPredicate, IExpression rightPredicate)
			: base(leftPredicate, rightPredicate) { }

		public override string ToString()
		{
			return "(" + leftPredicate.ToString() + " AND " + rightPredicate.ToString() + ")";
		}
	}
}