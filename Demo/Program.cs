using System;
using DatabaseAccessManagement;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			PublicClass pc = new PublicClass();
			pc.Print();

			Console.ReadKey();
		}
	}
}
