using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseAccessManagement
{
	public class MySqlRowCursorAdapter : IRowCursor
	{
		private MySqlDataReader reader;

		public MySqlRowCursorAdapter(MySqlDataReader reader)
		{
			this.reader = reader;
		}

		object IEnumerator.Current => (this as IEnumerator<IRow>).Current;
		IRow IEnumerator<IRow>.Current
		{
			get
			{
				IList<object> cells = new List<object>(reader.FieldCount);
				IDictionary<string, int> columnNameMap = new Dictionary<string, int>();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					cells.Add(reader[i]);
					columnNameMap[reader.GetName(i)] = i;
				}

				return new Row(cells, columnNameMap);
			}
		}

		public void Reset()
		{
			// Already reset
		}
		public bool MoveNext()
		{
			return reader.Read();
		}
		public void Dispose()
		{
			reader.Dispose();
		}
	}
}
