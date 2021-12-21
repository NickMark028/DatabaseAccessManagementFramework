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
			var x = new MySQLQueryBuilder<Actor>();
			x
				.Select()
				.Where(new SampleSQLPredicate())
				.Execute();

			var y = new MySQLQueryBuilder<Actor>();
			y
				.Select("actor_id", "first_name", "last_name")
				.Where(new SampleSQLPredicate())
				.Execute();



			Console.ReadKey();
		}
	}
}
