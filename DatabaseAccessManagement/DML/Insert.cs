using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public class StudentA
	{
		public int Id;
		public string Name;
		public float Score;
	}



	public class DML
	{
		public void Insert<A>()
		{

		}
	}

	public class MainProgram
	{
		public static void MainTest()
		{
			var x =new DML();
			x.Insert<StudentA>(new StudentA { Id = 10, Name ="Nguye Van A", Score = 1.4f});
		}
	}
}
