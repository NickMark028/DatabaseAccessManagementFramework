using System;
using DatabaseAccessManagement.SQLPredicate;
namespace DatabaseAccessManagement
{
	public class PublicClass
	{
		public void Print()
		{
			GreaterThanPredicate greater1 = new GreaterThanPredicate("Score", "5");
			GreaterThanPredicate greater2 = new GreaterThanPredicate("Score", "3");
			LessThanPredicate less1 = new LessThanPredicate("Score", "10");
			EqualToPredicate equal1 = new EqualToPredicate("Time", "5");

			AndPredicate and1 = new AndPredicate(greater2, less1);
			OrPredicate or1 = new OrPredicate(and1, equal1);

			OrPredicate or2 = new OrPredicate(greater1, or1);

			Console.WriteLine(or2.toString());

		}

	}
}
