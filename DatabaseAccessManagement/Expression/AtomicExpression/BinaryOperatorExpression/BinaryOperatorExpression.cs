using System;
namespace DatabaseAccessManagement
{
	public abstract class BinaryOperatorPredicate : IExpression
	{
		protected string leftMember;
		protected string rightMember;

		public BinaryOperatorPredicate(string leftMember, string rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = "'"+rightMember+"'"; 
		}
		public BinaryOperatorPredicate(string leftMember, Int64 rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember.ToString();
		}
		public BinaryOperatorPredicate(string leftMember, Decimal rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember.ToString();
		}
		public BinaryOperatorPredicate(string leftMember, Double rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember.ToString();
		}
		public BinaryOperatorPredicate(string leftMember, DateTime rightMember)
		{
			this.leftMember = leftMember;
			string temp = rightMember.ToString("yyyy/MM/dd HH:mm:ss");
			this.rightMember = "'" + temp + "'";
		}
		public BinaryOperatorPredicate(string leftMember, Boolean rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember.ToString();
		}

		public abstract override string ToString();
	}
}
