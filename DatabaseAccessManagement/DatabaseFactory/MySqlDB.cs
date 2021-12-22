using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public class MySqlDB : IDatabase
	{
		private string host;
		private int port;
		private string username;
		private string password;
		private string database;

		public MySqlDB(string host, int port, string database, string username, string password)
		{
			this.host = host;
			this.port = port;
			this.database = database;
			this.username = username;
			this.password = password;
		}
		public IConnection CreateConnection()
		{
			StringBuilder sb = new StringBuilder(128);
			sb.Append($"Server={host}");
			sb.Append($";Database={database}");
			sb.Append($";port={port}");
			sb.Append($";User id={username}");
			sb.Append($";password={password}");

			MySqlConnection conn = new MySqlConnection(sb.ToString());
			return new MySqlConnectionAdapter(conn);
		}
	}
}
