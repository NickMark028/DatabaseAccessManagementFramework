using System;
using System.Collections;
using System.Collections.Generic;
using DatabaseAccessManagement;

using LTP = DatabaseAccessManagement.LessThanExpression;
using LEP = DatabaseAccessManagement.LessThanOrEqualExpression;
using GTP = DatabaseAccessManagement.GreaterThanExpression;
using GEP = DatabaseAccessManagement.GreaterThanOrEqualExpression;

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

	class category
    {
		public int category_id { get; set; }
		public string name { get; set; }
		public DateTime last_update { get; set; }
    }
	class Program
	{
		public static void DemoSelect()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					Console.WriteLine("\nCreating a query builder ...");
					QueryBuilder<Country> qb = connection.CreateQueryBuilder<Country>();
					qb
						.Select("country_id", "country")
						.Where(predicate);
					Console.WriteLine(qb.ToString());

					Console.WriteLine("\nExecuting a select query ...");
					IRowCursor cursor = qb.Execute();

					Console.WriteLine("\nData result ...");
					while (cursor.MoveNext())
					{
						Console.Write(cursor.Current["country_id"] + "\t");
						Console.WriteLine(cursor.Current["country"]);
					}

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public static void DemoPrecidateToString()
		{
			IExpression predicate = new AndExpression(
				new OrExpression(
					new LEP("score", "5"),
					new GEP("age", "3")
				),
				new AndExpression(
					new EqualToExpression("id", "10"),
					new NotEqualToExpression("address", "Ocean")
				)
			);

			Console.WriteLine(predicate.ToString());

			//var queryBuilder = new MySQLQueryBuilder<Actor>();
			//queryBuilder
			//	.Select()
			//	.Where(predicate);
		}
		public static void DemoDmlToQueryString()
		{
			var x = new DML();
			//Console.WriteLine(x.Delete<StudentA>(new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			//Console.WriteLine();
			Console.WriteLine(x.Insert<StudentA>(new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			Console.WriteLine();

			Console.WriteLine(x.Delete<StudentA>(new EqualToExpression("Id", "10"), new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			Console.WriteLine();

			Console.WriteLine(x.Update<StudentA>(new EqualToExpression("Id", "10"), new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			Console.WriteLine();
		}
		public static void DemoInsert()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					Console.WriteLine("\nCreating a query builder ...");
					connection.Insert<category>(
						new object[] {
							new
							{
								name = "tu"
							},
							new
                            {
								name = "sdflsf"
                            },
							new
							{
								name = "zzzz"
							}
							,
							new
							{
								name = "2222"
							},
							new
							{
								name = "1111"
							}
						}
						) ;

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public static void DemoDelete()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					Console.WriteLine("\nCreating a query builder ...");
					connection.Delete<Country>(
							new EqualToExpression("country_id", "111")
						); ; ;

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static void Main(string[] args)
		{
			var x = new { };
			Console.WriteLine();


			//DemoDmlToQueryString();

			//DemoSelect();
			DemoInsert();
			//DemoDelete();
			//DemoInsert();
			//DemoDelete();
			DemoUpdate();
			//DemoToSqlString();
			//PublicClass.Print();

			//DemoSelect();
			Console.ReadKey();
		}
	}
}
