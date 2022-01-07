using System;
using System.Collections.Generic;

namespace DatabaseAccessManagement
{
	public interface IConnection : IDisposable
	{
		void Open();
		IRowCursor RunDqlQuery(string rawQuery);
		int RunDmlQuery(string rawQuery);
		QueryBuilder<T> CreateQueryBuilder<T>();
		int Insert<T>(object row);
		int Insert<T>(object[] rows);
		int Delete<T>(IExpression expression);
		int Update<T>(IExpression expression, object newValue);
		void Close();
	}
}
