using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Reflection.Core.Contracts
{
	public interface ICommandInterpreter
	{
		string Read(string args);
	}
}
