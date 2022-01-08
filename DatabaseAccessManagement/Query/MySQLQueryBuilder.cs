using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public class MySQLQueryBuilder<T> : QueryBuilder<T>
	{
		public MySQLQueryBuilder(IConnection connection)
			: base(connection) { }

		protected override string ToRawQueryString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			string columns = SelectedColumns == null ? "*": ArrayExtension.ToString(SelectedColumns);

			stringBuilder.Append($"SELECT {columns}");
			stringBuilder.Append($"\nFROM `{TableName}`");
			stringBuilder.Append($"\nWHERE {WhereExpression.ToString()}");
			stringBuilder.Append(";");
			return stringBuilder.ToString();
		}
	}
}
