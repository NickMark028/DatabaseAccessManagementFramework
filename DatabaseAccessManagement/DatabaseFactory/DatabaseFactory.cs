using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement.DatabaseFactory
{
	abstract class Database
	{
		public abstract void createConnection();

	}

	public class MySql : Database
    {
		private string host ;
        private int port ;
        private string database ;
        private string username ;
        private string password ;
		public MySql(string host, int port, string database,string username,string password) { 
			this.host = host;
			this.port = port;
			this.database = database;
			this.username = username;
			this.password=password
		}
		public override void createConnection()
        {
			  String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
			return 
        }
    }
}
