using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.IO.Contracts
{
	public interface IWritter
	{
		void Write(string text);

		void WriteLine(string text);
	}
}
