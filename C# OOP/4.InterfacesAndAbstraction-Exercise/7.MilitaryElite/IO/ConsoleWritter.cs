using _7.MilitaryElite.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.IO
{
	public class ConsoleWritter : IWritter
	{
		public void Write(string text)
		{
			Console.Write(text);
		}

		public void WriteLine(string text)
		{
			Console.WriteLine(text);
		}
	}
}
