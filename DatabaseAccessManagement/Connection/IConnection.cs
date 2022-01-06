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
		int Delete<T>(IExpression predicate);
		int Update<T>(IExpression predicate, object newValue);
		void Close();
	}
}
