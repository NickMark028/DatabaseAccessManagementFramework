using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
	static class ArrayExtension
	{
		public static string ToString<T>(T[] data)
		{
			if (data == null) return null;

			StringBuilder sb = new StringBuilder(128);

			sb.Append(data[0].ToString());
			for (int i = 1; i < data.Length; i++)
				sb.Append($", {data[i]}");

			return sb.ToString();
		}
	}
}
