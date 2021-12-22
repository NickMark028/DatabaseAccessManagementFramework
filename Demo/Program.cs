using System;
using System.Collections;
using System.Collections.Generic;
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
		public static void DemoConnectDB()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "sakila", "admin2", "MyPassWord456");
				IConnection connection = db.CreateConnection();
				connection.Open();

				var enumerator = connection.RunRawQuery("SELECT * FROM actor;");
				while (enumerator.MoveNext())
				{
					Console.Write(enumerator.Current["actor_id"] + "\t");
					Console.Write(enumerator.Current["first_name"] + ", ");
					Console.WriteLine(enumerator.Current["last_name"]);
				}

				//connection.Insert<Program>(new string[1]);
				connection.Close();

				Console.WriteLine("Success");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				//throw;
			}
		}
		public static void DemoToSqlString()
		{
			//var x = new MySQLQueryBuilder<Actor>();
			//x
			//	.Select()
			//	.Where(new AndPredicate(
			//		new OrPredicate(
			//			new LessThanOrEqualPredicate("score", "5"),
			//			new GreaterThanOrEqualPredicate("age", "3")
			//		),
			//		new AndPredicate(
			//			new EqualToPredicate("id", "10"),
			//			new NotEqualToPredicate("address", "Ocean")
			//		)
			//	))
			//	.Execute();
		}

		public static void Main(string[] args)
		{
			DemoConnectDB();
			Console.ReadKey();
		}
	}
}
