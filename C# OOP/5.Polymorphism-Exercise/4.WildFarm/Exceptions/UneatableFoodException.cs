using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Exceptions
{
	public class UneatableFoodException : Exception
	{
		public UneatableFoodException(string message)
			: base(message)
		{
		}
	}
}
