using _3.Telephony.Contracts;
using _3.Telephony.Core;
using System;

namespace _3.Telephony
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			IEngine engine = new Engine();
			engine.Run();
		}
	}
}
