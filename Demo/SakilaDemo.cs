using DatabaseAccessManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
	class Actor
	{
		public int actor_id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public DateTime last_update { get; set; }
	}

	class Country
	{
		public int country_id { get; set; }
		public string country { get; set; }
		public DateTime last_update { get; set; }
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
				IDatabase db = new MySqlDb("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IExpression predicate = new OrExpression(
						new AndExpression(new GreaterThanExpression("country_id", "10"), new LessThanOrEqualExpression("country_id", "30")),
						new EqualToExpression("country_id", "100")
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
		public void DemoInsert()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					Console.WriteLine("\nInserting ...");
					connection.Insert<Category>(new { name = "tu" });
					Console.WriteLine("\nClosing connection ...");
				}

				Console.WriteLine("\nDone.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public void DemoInsertMany()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					Console.WriteLine("\nInserting many ...");
					connection.Insert<Category>(
						new object[] {
							new
							{
								name = "tu",
								last_update = new DateTime(2021, 10, 10)
							},
							new
							{
								name = "sdflsf",
								last_update = new DateTime(2021, 10, 10)
							},
							new
							{
								name = "zzzz",
								last_update = new DateTime(2021, 10, 10)
							}
							,
							new
							{
								name = "2222",
								last_update = new DateTime(2021, 10, 10)

							},
							new
							{
								name = "1111",
								last_update = new DateTime(2021, 10, 10)
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
		public void DemoDelete()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					Console.WriteLine("\nDeleting ...");
					connection.Delete<Category>(new EqualToExpression("category_id", 18));

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
				IDatabase db = new MySqlDb("localhost", 3306, "root", "28200752889396tu", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					Console.WriteLine("\nUpdating");
					connection.Update<Category>(
						new EqualToExpression("category_id", 10),
						new { name = "ZZZZZZZZZZZZZZZZZZZ", last_update = new DateTime(2015, 10, 15) }
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
