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
		public IRowCursor RunDqlQuery(string rawQuery)
		{
			MySqlCommand cmd = new MySqlCommand(rawQuery, connection);
			return new MySqlRowCursorAdapter(cmd.ExecuteReader());
		}
		public int RunDmlQuery(string rawQuery)
		{
			MySqlCommand cmd = new MySqlCommand(rawQuery, connection);
			return cmd.ExecuteNonQuery();
		}
		public QueryBuilder<T> CreateQueryBuilder<T>()
		{
			return new MySQLQueryBuilder<T>(this);
		}
		int IConnection.Insert<T>(object obj)
		{
			var objects = new object[1];
			objects[0] = obj;
			return (this as IConnection).Insert<T>(objects);
		}
		int IConnection.Insert<T>(object[] obj)
		{
			string queryString = "INSERT INTO " + typeof(T).Name + " ";
			string columnString = "(";
			foreach (var prop in obj[0].GetType().GetProperties())
			{
				columnString += prop.Name + ", ";
			}

			columnString = columnString.Remove(columnString.Length - 2, 2);
			columnString += ")";

			string valuesString = "";

			foreach (var item in obj)
			{
				valuesString += "\n(";
				foreach (var prop in item.GetType().GetProperties())
				{
					if (prop.PropertyType == typeof(string))
					{
						valuesString += "'" + prop.GetValue(item) + "'" + ", ";
					}
					else if (prop.PropertyType == typeof(DateTime))
					{
						string temp = (((DateTime)prop.GetValue(item))).ToString("MM/dd/yyyy HH:mm:ss");
						valuesString += "'" + temp + "'" + ", ";
					}
					else
					{
						valuesString += prop.GetValue(item) + ", ";
					}
				}
				valuesString = valuesString.Remove(valuesString.Length - 2, 2);
				valuesString += "), ";
			}
			valuesString = valuesString.Remove(valuesString.Length - 2, 2);
			queryString += columnString + " \nVALUES " + valuesString;

			return RunDmlQuery(queryString);
		}
		int IConnection.Delete<T>(IExpression predicate)
		{
			string queryString = "DELETE FROM " + typeof(T).Name;
			queryString += "\nWHERE " + predicate.ToString();
			return RunDmlQuery(queryString);
		}
		int IConnection.Update<T>(IExpression predicate, object obj)
		{
			string queryString = "UPDATE " + typeof(T).Name + "\nSET ";
			string setString = "";
			foreach (var prop in obj.GetType().GetProperties())
			{
				if (prop.PropertyType == typeof(string))
				{
					setString += prop.Name + " = '" + prop.GetValue(obj) + "' ";
				}
				else if (prop.PropertyType == typeof(DateTime))
				{
					string temp = (((DateTime)prop.GetValue(obj))).ToString("MM/dd/yyyy HH:mm:ss");
					setString += "'" + temp + "'" + ", ";
				}
				else
				{
					setString += prop.Name + " = " + prop.GetValue(obj);
				}
				setString += ", ";
			}
			setString = setString.Remove(setString.Length - 2, 2);

			queryString += setString + "\nWHERE " + predicate.ToString();

			return RunDmlQuery(queryString);
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
