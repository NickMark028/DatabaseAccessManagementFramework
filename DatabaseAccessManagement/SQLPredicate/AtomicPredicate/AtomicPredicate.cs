using System;

namespace DatabaseAccessManagement
{
	public interface AtomicPredicate : SQLPredicate { }

	public abstract class BinaryComparisionPredicate : SQLPredicate
	{
		protected string leftMember;
		protected string rightMember;

		public BinaryComparisionPredicate(string leftMember, string rightMember)
		{
			this.leftMember = leftMember;
			this.rightMember = rightMember;
		}
	}

	public class LessThanPredicate : BinaryComparisionPredicate
	{
		public LessThanPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " < " + rightMember;
		}
	}

	public class LessThanOrEqualPredicate : BinaryComparisionPredicate
	{
		public LessThanOrEqualPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " <= " + rightMember;
		}
	}

	public class EqualToPredicate : BinaryComparisionPredicate
	{
		public EqualToPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " = " + rightMember;
		}
	}

	public class NotEqualToPredicate : BinaryComparisionPredicate
	{
		public NotEqualToPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " != " + rightMember;
		}
	}

	public class GreaterThanPredicate : BinaryComparisionPredicate
	{
		public GreaterThanPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " > " + rightMember;
		}
	}

	public class GreaterThanOrEqualPredicate : BinaryComparisionPredicate
	{
		public GreaterThanOrEqualPredicate(string leftMember, string rightMember)
			: base(leftMember, rightMember) { }

		public override string ToString()
		{
			return leftMember + " >= " + rightMember;
		}
	}
}
