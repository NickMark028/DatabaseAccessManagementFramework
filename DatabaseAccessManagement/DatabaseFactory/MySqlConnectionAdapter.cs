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
		public void Insert<T>(object[] rows)
		{
			MySqlCommand cmd = new MySqlCommand("INSERT INTO actor (first_name, last_name) VALUE (\"First\", \"Last\");", connection);
			cmd.ExecuteNonQuery();
		}
		public void Delete<T>(IPredicate predicate)
		{
			throw new NotImplementedException();
		}
		public void Update<T>(IPredicate predicate, object newValue)
		{
			throw new NotImplementedException();
		}
		public void Close()
		{
			connection.Close();
			connection.Dispose();
		}

		public IEnumerator<IDictionary<string, object>> RunRawQuery(string query)
		{
			MySqlCommand cmd = new MySqlCommand(query, connection);
			return new MySqlRowCursor(cmd.ExecuteReader());
		}
	}
}
