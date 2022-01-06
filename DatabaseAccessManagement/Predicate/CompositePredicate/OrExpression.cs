namespace DatabaseAccessManagement
{
	public class OrExpression : CompositeExpression
	{
		public OrExpression(IExpression leftPredicate, IExpression rightPredicate)
			: base(leftPredicate, rightPredicate) { }

		public override string ToString()
		{
			return "(" + leftPredicate.ToString() + " OR " + rightPredicate.ToString() + ")";
		}
	}
}