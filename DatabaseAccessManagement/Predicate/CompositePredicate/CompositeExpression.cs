namespace DatabaseAccessManagement
{
	public abstract class CompositeExpression : IExpression
	{
		protected IExpression leftPredicate;
		protected IExpression rightPredicate;

		public CompositeExpression(IExpression leftPredicate, IExpression rightPredicate)
		{
			this.leftPredicate = leftPredicate;
			this.rightPredicate = rightPredicate;
		}

		public abstract override string ToString();
	}
}
