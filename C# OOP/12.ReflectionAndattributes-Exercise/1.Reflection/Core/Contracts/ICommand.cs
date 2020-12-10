using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Reflection.Core.Contracts
{
	public interface ICommand
	{
		string Execute(string[] args);
	}
}
