namespace DatabaseAccessManagement
{
	public class OrExpression : CompositeExpression
	{
		public OrExpression(IExpression leftExpression, IExpression rightExpression)
			: base(leftExpression, rightExpression) { }

		public override string ToString()
		{
			return "(" + leftExpression.ToString() + " OR " + rightExpression.ToString() + ")";
		}
	}
}
