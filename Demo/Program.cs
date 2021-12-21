using System;
using DatabaseAccessManagement;

namespace Demo
{
	class Actor
	{
		public int actor_id;
		public string first_name;
		public string last_name;
		public DateTime last_update;
	}

	class Program
	{
		static void Main(string[] args)
		{
			GreaterThanPredicate greater1 = new GreaterThanPredicate("Score", "5");
			GreaterThanPredicate greater2 = new GreaterThanPredicate("Score", "3");
			LessThanPredicate less1 = new LessThanPredicate("Score", "10");
			EqualToPredicate equal1 = new EqualToPredicate("Time", "5");

			AndPredicate and1 = new AndPredicate(greater2, less1);
			OrPredicate or1 = new OrPredicate(and1, equal1);

			OrPredicate or2 = new OrPredicate(greater1, or1);

			var x = new MySQLQueryBuilder<Actor>();
			x
				.Select()
				.Where(new AndPredicate(
					new OrPredicate(
						new LessThanOrEqualPredicate("score", "5"),
						new GreaterThanOrEqualPredicate("age", "3")
					),
					new AndPredicate(
						new EqualToPredicate("id", "10"),
						new NotEqualToPredicate("address", "Ocean")
					)
				))
				.Execute();

			Console.ReadKey();
		}
	}
}
