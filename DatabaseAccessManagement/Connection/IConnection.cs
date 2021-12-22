using System;
using System.Collections.Generic;

namespace DatabaseAccessManagement
{
	public interface IConnection : IDisposable
	{
		void Open();
		IEnumerator<IDictionary<string, object>> RunRawQuery(string query);
		QueryBuilder<T> CreateQueryBuilder<T>();
		void Insert<T>(object[] rows);
		void Delete<T>(IPredicate predicate);
		void Update<T>(IPredicate predicate, object newValue);
		void Close();
	}
}
