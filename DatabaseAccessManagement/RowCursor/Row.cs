using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public class Row
	{
		private IList<object> cells;
		private IDictionary<string, int> columnNameMap;

		public Row(IList<object> cells, IDictionary<string, int> columnNameMap)
		{
			this.cells = cells;
			this.columnNameMap = columnNameMap;
		}

		public object this[int index] => cells[index];
		public object this[string columName] => cells[columnNameMap[columName]];
	}
}
