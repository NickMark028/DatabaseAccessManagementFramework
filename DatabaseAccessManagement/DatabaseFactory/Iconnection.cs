using System.Collections.Generic;

namespace DatabaseAccessManagement
{
	public interface IConnection
	{
		void Open();
		IEnumerator<IDictionary<string, object>> RunRawQuery(string query);
		void Insert<T>(object[] rows);
		void Delete<T>(SQLPredicate predicate);
		void Update<T>(SQLPredicate predicate, object newValue);
		void Close();
	}
}
