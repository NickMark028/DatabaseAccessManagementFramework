using DatabaseAccessManagement;
using System;
using System.Collections.Generic;
using System.Text;

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

	class Category
	{
		public int category_id { get; set; }
		public string name { get; set; }
		public DateTime last_update { get; set; }
	}

	class SakilaDemo
	{
		public void DemoSelect()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GreaterThanExpression("country_id", "10"), new LessThanOrEqualExpression("country_id", "30")),
						new GreaterThanExpression("country_id", "100")
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
		public void DemoPrecidateToString()
		{
			IExpression expression = new AndExpression(
				new OrExpression(
					new LessThanExpression("score", "5"),
					new GreaterThanExpression("age", "3")
				),
				new AndExpression(
					new EqualToExpression("id", "10"),
					new NotEqualToExpression("address", "Ocean")
				)
			);

			Console.WriteLine(expression.ToString());

			//var queryBuilder = new MySQLQueryBuilder<Actor>();
			//queryBuilder
			//	.Select()
			//	.Where(predicate);
		}
		public void DemoDmlToQueryString()
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
		public void DemoInsertMany()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GreaterThanExpression("country_id", "10"), new LessThanExpression("country_id", "30")),
						new GreaterThanExpression("country_id", "100")
					);

					Console.WriteLine("\nInserting many ...");
					connection.Insert<Category>(
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
						);

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public void DemoInsert()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new GreaterThanExpression("country_id", "1");

					Console.WriteLine("\nInserting ...");
					connection.Insert<Country>(
						new Country { country = "Afghanistan" }
						);

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public void DemoDelete()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GreaterThanExpression("country_id", "10"), new LessThanExpression("country_id", "30")),
						new GreaterThanExpression("country_id", "100")
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
		public void DemoUpdate()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();



					Console.WriteLine("\nUpdating");
					connection.Update<TaskToDo>(
						new EqualToExpression("country_id", "10"), new
						{
							country = "newcountry"
						}
						);

					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
