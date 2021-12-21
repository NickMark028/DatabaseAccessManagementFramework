using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public interface IDatabase
	{
		IConnection CreateConnection();
	}

	public class MySql : IDatabase
	{
		private string host;
		private int port;
		private string username;
		private string password;
		private string database;

		public MySql(string host, int port, string database, string username, string password)
		{
			this.host = host;
			this.port = port;
			this.database = database;
			this.username = username;
			this.password = password;
		}
		public IConnection CreateConnection()
		{
			string connString = "Server=" + host + ";Database=" + database
				+ ";port=" + port + ";User Id=" + username + ";password=" + password;

			MySqlConnection conn = new MySqlConnection(connString);
			return new MySqlConnectionAdapter(conn);
		}
	}
}
