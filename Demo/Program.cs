﻿using System;
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

					IPredicate predicate = new OrPredicate(
						new AndPredicate(new GTP("country_id", "10"), new LEP("country_id", "30")),
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

			Console.WriteLine(x.Delete<StudentA>(new EqualToPredicate("Id", "10"), new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			Console.WriteLine();

			Console.WriteLine(x.Update<StudentA>(new EqualToPredicate("Id", "10"), new StudentA { Name = "Nguyen Van A", Id = 10, Score = 5.5f }));
			Console.WriteLine();
		}
		public static void DemoInsert()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IPredicate predicate = new OrPredicate(
						new AndPredicate(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					Console.WriteLine("\nCreating a query builder ...");
					connection.Insert<Country>(
						new Country[] { new Country() { country = "Afghanistan" }, new Country() { country = "hahahihi" } }
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

			public static void DemoInsertOneRow()
		{
			try
			{
				IDatabase db = new MySqlDB("localhost", 3306, "root", "admin123", "sakila");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					IPredicate predicate = new GEP("country_id", "101");
					
						
					

					Console.WriteLine("\nCreating a query builder ...");
					connection.Insert<Country>(
						new Country{  country = "Afghanistan"  }
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

					IPredicate predicate = new OrPredicate(
						new AndPredicate(new GTP("country_id", "10"), new LEP("country_id", "30")),
						new GEP("country_id", "100")
					);

					Console.WriteLine("\nCreating a query builder ...");
					connection.Delete<Country>(
							new EqualToPredicate("country_id", "111")
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

			//x.GetType().GetProperties;

			//DemoDmlToQueryString();

			//DemoSelect();
			//DemoInsert();
			//DemoDelete();
			//DemoToSqlString();
			//PublicClass.Print();
			//*** DemoInsertOneRow();
			//DemoSelect();
			Console.ReadKey();
		}
	}
}
