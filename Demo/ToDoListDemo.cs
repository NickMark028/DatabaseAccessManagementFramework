using DatabaseAccessManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
	class TaskToDo
	{
		public int id { get; set; }
		public string task { get; set; }
		public bool isdone { get; set; }
	}

	class ToDoListDemo
	{
		public void DemoSelect()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "todolist");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();

					Console.WriteLine("\nCreating a query builder ...");
					QueryBuilder<TaskToDo> qb = connection.CreateQueryBuilder<TaskToDo>();
					qb
						.Select("id", "task")
						.Where(new EqualToExpression("isdone", "FALSE"));
					Console.WriteLine(qb.ToString());

					Console.WriteLine("\nExecuting a select query ...");
					IRowCursor cursor = qb.Execute();

					Console.WriteLine("\nData result ...");
					while (cursor.MoveNext())
					{
						Console.Write(cursor.Current["id"] + "\t");
						Console.WriteLine(cursor.Current["task"]);
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
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "todolist");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();



					Console.WriteLine("\nCreating a query builder ...");
					connection.Insert<TaskToDo>(
						new TaskToDo[] { new TaskToDo() { task = "test10", isdone = false }, new TaskToDo() { task = "test11", isdone = true } }
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
		public void DemoInsertMany()
		{
			try
			{
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "todolist");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();



					Console.WriteLine("\nCreating a query builder ...");
					connection.Insert<TaskToDo>(
						new TaskToDo[] { new TaskToDo() { task = "test10", isdone = false }, new TaskToDo() { task = "test11", isdone = true } }
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
				IDatabase db = new MySqlDb("localhost", 3306, "root", "admin123", "todolist");

				Console.WriteLine("Creating connection ...");
				using (IConnection connection = db.CreateConnection())
				{
					Console.WriteLine("\nOpening connection ...");
					connection.Open();



					Console.WriteLine("\nCreating a query builder ...");
					connection.Delete<TaskToDo>(
							new EqualToExpression("id", "1")
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

        }
	}


}
