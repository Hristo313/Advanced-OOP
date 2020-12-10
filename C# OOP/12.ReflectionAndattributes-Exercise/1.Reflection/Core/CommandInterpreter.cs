using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _1.Reflection.Core.Contracts;

namespace _1.Reflection.Core
{
	//Holds all the reflection we should do in order to execute a command
	public class CommandInterpreter : ICommandInterpreter
	{
		private const string COMMAND_POSTFIX = "Command";

		public CommandInterpreter()
		{
		}

		//Parses the input and execute coorect command
		public string Read(string args)
		{
			string[] command = args.Split();

			string name = command[0] + COMMAND_POSTFIX;
			string[] commandArgs = command.Skip(1).ToArray();

			//Get assembly in order to get types
			Assembly assembly = Assembly.GetCallingAssembly();

			//Get concrete command type in order to produce instance of concrete command
			Type commandType = assembly
				.GetTypes()
				.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());

			if(commandType == null)
			{
				throw new ArgumentException("Invalid command type!");
			}

			//Solution with constructors 
			//ConstructorInfo constructor = commandType
			//	.GetConstructors()
			//	.FirstOrDefault(c => c.GetParameters().Length == 0);
			//ICommand commandInstance = (ICommand)constructor.Invoke(new object[] { });

			//Creates instance of concrete command in order to invoke Execute()
			ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

			string result = commandInstance.Execute(commandArgs);

			return result;
		}
	}
}
