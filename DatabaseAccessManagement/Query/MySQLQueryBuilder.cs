using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public class MySQLQueryBuilder<T> : QueryBuilder<T>
	{
		private StringBuilder stringBuilder;

		public MySQLQueryBuilder()
		{
			stringBuilder = new StringBuilder(64);
		}

		protected override string ToRawQueryString()
		{
			string columns = SelectedColumns == null ? "*": ArrayExtension.ToString(SelectedColumns);

			stringBuilder.Append($"SELECT {columns}");
			stringBuilder.Append($" FROM {TableName}");
			//stringBuilder.Append($" WHERE {WherePredicate.ToString()}");
			stringBuilder.Append(";");
			return stringBuilder.ToString();
		}
	}
}
