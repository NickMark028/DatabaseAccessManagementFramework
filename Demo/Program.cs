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
		public static void Main(string[] args)
		{
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
