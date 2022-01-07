using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public abstract class QueryBuilder<T>
	{
		private IConnection connection;

		public QueryBuilder(IConnection connection)
		{
			this.connection = connection;
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
		public QueryBuilder<T> Where(IExpression predicate)
		{
			WhereExpression = predicate;
			return this;
		}
		public IRowCursor Execute()
		{
			string rawSQL = ToRawQueryString();
			return connection.RunDqlQuery(rawSQL);
		}

		protected string[] SelectedColumns { get; private set; }
		protected IExpression WhereExpression { get; private set; }
		protected string TableName { get; private set; }

		protected abstract string ToRawQueryString();
	}
}
