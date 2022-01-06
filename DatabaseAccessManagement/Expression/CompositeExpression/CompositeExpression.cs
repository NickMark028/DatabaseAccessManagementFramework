namespace DatabaseAccessManagement
{
	public abstract class CompositeExpression : IExpression
	{
		protected IExpression leftExpression;
		protected IExpression rightExpression;

		public CompositeExpression(IExpression leftExpression, IExpression rightExpression)
		{
			this.leftExpression = leftExpression;
			this.rightExpression = rightExpression;
		}

		public abstract override string ToString();
	}
}
