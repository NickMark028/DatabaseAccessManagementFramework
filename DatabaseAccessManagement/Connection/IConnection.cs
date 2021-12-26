using System;
using System.Collections.Generic;

namespace DatabaseAccessManagement
{
	public interface IConnection : IDisposable
	{
		void Open();
		IRowCursor RunDqlQuery(string query);
		QueryBuilder<T> CreateQueryBuilder<T>();
		int Insert<T>(object[] rows);
		int Delete<T>(IPredicate predicate);
		int Update<T>(IPredicate predicate, object newValue);
		void Close();
	}
}
