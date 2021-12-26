using System;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public static class PublicClass
	{
		//public static void Print()
		//{
		//	string host = "localhost";
		//	string database = "sakila";
		//	int port = 3306;
		//	string username = "admin2";
		//	string password = "MyPassWord456";

		//	StringBuilder sb = new StringBuilder(128);
		//	sb.Append($"Server={host}");
		//	sb.Append($";Database={database}");
		//	sb.Append($";port={port}");
		//	sb.Append($";User id={username}");
		//	sb.Append($";password={password}");


		//	using (MySqlConnection conn = new MySqlConnection(sb.ToString()))
		//	{
		//		conn.Open();

		//		MySqlCommand cmd = conn.CreateCommand();
		//		cmd.CommandText = "SELECT * FROM country CO JOIN city CI ON CO.country_id = CI.country_id LIMIT 0, 1000;";

		//		MySqlDataReader reader = cmd.ExecuteReader();
		//		while(reader.Read())
		//		{
		//			Console.WriteLine(reader["country_id"]);
		//		}
		//	}
		//}
	}
}
