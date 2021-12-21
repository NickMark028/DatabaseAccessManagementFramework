using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public class MySqlRowCursor : IEnumerator<IDictionary<string, object>>
	{
		private MySqlDataReader reader;

		public MySqlRowCursor(MySqlDataReader reader)
		{
			this.reader = reader;
		}

		public IDictionary<string, object> Current
		{
			get
			{
				IDictionary<string, object> result = new Dictionary<string, object>();

				string columnName;
				for (int i = 0; i < reader.FieldCount; i++)
				{
					columnName = reader.GetName(i);
					result[columnName] = reader[i];
				}

				return result;
			}
		}
		object IEnumerator.Current => Current;

		public void Dispose()
		{
			reader.Dispose();
		}
		public bool MoveNext()
		{
			return reader.Read();
		}
		public void Reset()
		{
			// Already reset
		}
	}
}
