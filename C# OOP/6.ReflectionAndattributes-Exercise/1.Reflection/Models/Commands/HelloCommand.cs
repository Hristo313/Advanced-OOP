using _1.Reflection.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ICommand = _1.Reflection.Core.Contracts.ICommand;

namespace _1.Reflection.Models.Commands
{
	public class HelloCommand : ICommand
	{
		public string Execute(string[] args)
		{
			return $"Hello, {args[0]}";
		}
	}
}
