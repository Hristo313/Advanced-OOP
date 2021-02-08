using _1.Reflection.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Reflection.Models.Commands
{
	public class ExitCommand : ICommand
	{
		public string Execute(string[] args)
		{
			Environment.Exit(0);

			return null;
		}
	}
}
