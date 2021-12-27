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
		int IConnection.Insert<T>(object[] obj)
		{
			string queryString = "INSERT INTO " + obj[0].GetType().Name + " ";
			string columnString = "(";
			foreach (var prop in obj[0].GetType().GetFields())
			{
				columnString += prop.Name + ", ";
			}
			columnString = columnString.Remove(columnString.Length - 2, 2);
			columnString += ")";

			string valuesString = "";

			foreach (var item in obj)
			{
				valuesString += "\n(";
				foreach (var prop in item.GetType().GetFields())
				{
					if (prop.FieldType == typeof(string))
						valuesString += "'" + prop.GetValue(item) + "'" + ", ";
					else valuesString += prop.GetValue(item) + ", ";
				}
				valuesString = valuesString.Remove(valuesString.Length - 2, 2);
				valuesString += "), ";
			}
			valuesString = valuesString.Remove(valuesString.Length - 2, 2);
			queryString += columnString + " \nVALUES " + valuesString;
			
			MySqlCommand cmd = new MySqlCommand(queryString, connection);
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
