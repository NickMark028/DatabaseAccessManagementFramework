using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public interface ISQLPredicate
	{
		string ToString();
	}

	public class SampleSQLPredicate : ISQLPredicate
	{
		public override string ToString()
		{
			return "actor_id < 30";
		}
	}

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
		public QueryBuilder<T> Where(ISQLPredicate predicate)
		{
			WherePredicate = predicate;
			return this;
		}
		public object[] Execute()
		{
			string rawSQL = ToRawQueryString();
			Console.WriteLine(rawSQL);	//? Testing
			return null;    // Todo: Execute query on the connection
		}

		protected string[] SelectedColumns { get; private set; }
		protected ISQLPredicate WherePredicate { get; private set; }
		protected string TableName { get; private set; }

		protected abstract string ToRawQueryString();
	}
}
