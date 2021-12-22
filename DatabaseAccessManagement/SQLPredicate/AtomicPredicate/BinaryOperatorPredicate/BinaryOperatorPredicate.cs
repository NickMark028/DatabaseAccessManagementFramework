﻿namespace DatabaseAccessManagement
{
	public abstract class BinaryOperatorPredicate : SQLPredicate
	{
		protected string leftMember;
		protected string rightMember;

		public BinaryOperatorPredicate(string leftMember, string rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember;
		}
	}
}
