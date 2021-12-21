using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement.Query
{
	interface ISQLPredicate { }

	abstract class QueryBuilder
	{
		public abstract void Select();
		public abstract void Select(params string[] columns);
		public abstract void Where(ISQLPredicate predicate);
		public object[] Execute()
		{
			string rawSQL = ToRawQueryString();
			return null;	// Todo: asdas
		}

		protected abstract string ToRawQueryString();
	}
}
