namespace DatabaseAccessManagement
{
	public class AndExpression : CompositeExpression
	{
		public AndExpression(IExpression leftExpression, IExpression rightExpression)
			: base(leftExpression, rightExpression) { }

		public override string ToString()
		{
			return "(" + leftExpression.ToString() + " AND " + rightExpression.ToString() + ")";
		}
	}
}