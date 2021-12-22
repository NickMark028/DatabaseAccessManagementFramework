using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public abstract class QueryBuilder<T>
	{
		public QueryBuilder()
		{
			TableName = typeof(T).Name;
		}

		public QueryBuilder<T> Select()
		{
			SelectedColumns = null;
			return this;
		}
		public QueryBuilder<T> Select(params string[] columns)
		{
			SelectedColumns = columns;
			return this;
		}
		public QueryBuilder<T> Where(IPredicate predicate)
		{
			WherePredicate = predicate;
			return this;
		}
		public IEnumerator<IDictionary<string, object>> Execute(IConnection connection)
		{
			string rawSQL = ToRawQueryString();
			Console.WriteLine(rawSQL);  //? Testing
										//return null;    // Todo: Execute query on the connection
			return connection.RunRawQuery(rawSQL);
		}

		protected string[] SelectedColumns { get; private set; }
		protected IPredicate WherePredicate { get; private set; }
		protected string TableName { get; private set; }

		protected abstract string ToRawQueryString();
	}
}
