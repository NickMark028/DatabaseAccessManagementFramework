using System;
using System.Collections;
using System.Collections.Generic;
using DatabaseAccessManagement;

using LTP = DatabaseAccessManagement.LessThanPredicate;
using LEP = DatabaseAccessManagement.LessThanOrEqualPredicate;
using GTP = DatabaseAccessManagement.GreaterThanPredicate;
using GEP = DatabaseAccessManagement.GreaterThanOrEqualPredicate;

namespace Demo
{
	class Actor
	{
		public int actor_id;
		public string first_name;
		public string last_name;
		public DateTime last_update;
	}

	class Country
	{
		public int country_id;
		public string country;
		public DateTime last_update;
	}

	class Program
	{
		public static void DemoConnectDB()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "sakila", "admin2", "MyPassWord456");

				using (IConnection connection = db.CreateConnection())
				{
					connection.Open();

					IPredicate predicate = new OrPredicate(
						new AndPredicate(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					QueryBuilder<Country> qb = connection.CreateQueryBuilder<Country>();
					qb
						.Select("country_id", "country")
						.Where(predicate);

					IEnumerator<IDictionary<string, object>> enumerator = qb.Execute(connection);
						
					while (enumerator.MoveNext())
					{
						Console.Write(enumerator.Current["country_id"] + "\t");
						Console.WriteLine(enumerator.Current["country"]);
					}
				}

				Console.WriteLine("Success");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public static void DemoToSqlString()
		{
			IPredicate predicate = new AndPredicate(
				new OrPredicate(
					new LEP("score", "5"),
					new GEP("age", "3")
				),
				new AndPredicate(
					new EqualToPredicate("id", "10"),
					new NotEqualToPredicate("address", "Ocean")
				)
			);

			var queryBuilder = new MySQLQueryBuilder<Actor>();
			queryBuilder
				.Select()
				.Where(predicate);
		}

		public static void Main(string[] args)
		{
			DemoConnectDB();
			//DemoToSqlString();
			Console.ReadKey();
		}
	}
}
