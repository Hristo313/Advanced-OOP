using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Exceptions
{
	public class InvalidMissionStateException : Exception
	{
		private const string DEF_EXC_MSG = "Invalid mission state!";

		public InvalidMissionStateException()
			: base(DEF_EXC_MSG)
		{
		}

		public InvalidMissionStateException(string message)
			: base(message)
		{
		}
	}
}
