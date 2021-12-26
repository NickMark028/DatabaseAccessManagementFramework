using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public class MySqlConnectionAdapter : IConnection
	{
		private MySqlConnection connection;

		public MySqlConnectionAdapter(MySqlConnection connection)
		{
			this.connection = connection;
		}

		public void Open()
		{
			connection.Open();
		}
		public IRowCursor RunDqlQuery(string query)
		{
			MySqlCommand cmd = new MySqlCommand(query, connection);
			return new MySqlRowCursor(cmd.ExecuteReader());
		}
		public QueryBuilder<T> CreateQueryBuilder<T>()
		{
			return new MySQLQueryBuilder<T>(this);
		}
		int IConnection.Insert<T>(object[] rows)
		{
			MySqlCommand cmd = new MySqlCommand("INSERT INTO actor (first_name, last_name) VALUE (\"First\", \"Last\");", connection);
			return cmd.ExecuteNonQuery();
		}
		int IConnection.Delete<T>(IPredicate predicate)
		{
			throw new NotImplementedException();
		}
		int IConnection.Update<T>(IPredicate predicate, object newValue)
		{
			throw new NotImplementedException();
		}
		public void Close()
		{
			connection.Close();
		}
		public void Dispose()
		{
			connection.Dispose();
		}
	}
}
