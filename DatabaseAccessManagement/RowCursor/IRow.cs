using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	public interface IRow
	{
		object this[int index] { get; }
		object this[string columeName] { get; }
	}
}
