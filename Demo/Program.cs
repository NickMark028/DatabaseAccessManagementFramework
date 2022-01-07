using System;

namespace Demo
{
	class Program
	{
		public static void Main(string[] args)
		{
			var sakilaDemo = new SakilaDemo();
			sakilaDemo.DemoSelect();
			sakilaDemo.DemoInsertMany();
			sakilaDemo.DemoDelete();

			var toDoListDemo = new ToDoListDemo();
			toDoListDemo.DemoSelect();
			toDoListDemo.DemoInsert();
			toDoListDemo.DemoDelete();

			Console.ReadKey();
		}
	}
}
