using System;
using System.Collections.Generic;
using System.Text;
using _1.Reflection.Core.Contracts;

namespace _1.Reflection.Core
{
	public class Engine : IEngine
	{
		private readonly ICommandInterpreter commandInterpreter;

		public Engine(ICommandInterpreter commandInterpreter)
		{
			this.commandInterpreter = commandInterpreter;
		}

		public void Run()
		{
			while (true)
			{
				string args = Console.ReadLine();

				try
				{
					string result = this.commandInterpreter.Read(args);

					Console.WriteLine(result);
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
			}
		}
	}
}
