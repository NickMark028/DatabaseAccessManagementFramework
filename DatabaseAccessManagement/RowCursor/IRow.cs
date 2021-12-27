using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	interface IRow
	{
		object this[int index] { get; }
		object this[string columeName] { get; }
	}
}
