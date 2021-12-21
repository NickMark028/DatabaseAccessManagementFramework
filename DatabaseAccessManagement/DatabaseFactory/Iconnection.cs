using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public interface IConnection
	{
		void RunRawQuery(string query);
		void Insert<T>(object[] rows);
		void Delete<T>(SQLPredicate predicate);
		void Update<T>(SQLPredicate predicate, object newValue);
		void Close();
	}

	public class MySqlConnectionAdapter : IConnection
	{
		private MySqlConnection connection;

		public MySqlConnectionAdapter(MySqlConnection connection)
		{
			this.connection = connection;
		}

		public void RunRawQuery(string query)
		{
			MySqlCommand cmd = new MySqlCommand(query, connection);
			//if select
			MySqlDataReader rdr = cmd.ExecuteReader();
			//if insert/update/delete
			cmd.ExecuteNonQuery();

		}
		public void Insert<T>(object[] rows)
		{
			throw new NotImplementedException();
		}
		public void Delete<T>(SQLPredicate predicate)
		{
			throw new NotImplementedException();
		}
		public void Update<T>(SQLPredicate predicate, object newValue)
		{
			throw new NotImplementedException();
		}
		public void Close()
		{
			connection.Close();
			connection.Dispose();
		}
	}
}
