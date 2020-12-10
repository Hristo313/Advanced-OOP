using System;
using System.Runtime.CompilerServices;

namespace _3.StudentSystem
{
	public class Engine
	{
		private readonly StudentData studentData;

		public Engine(StudentData studentData)
		{
			this.studentData = new StudentData();
		}

		public void Process()
		{
			while (true)
			{
				var line = Console.ReadLine();

				var command = Command.Parse(line);

				var name = command.Name;
				var arguments = command.Arguments;

				switch (command.Name)
				{
					case "Create":
						this.studentData.Add(arguments[0],
							int.Parse(arguments[1]),
							double.Parse(arguments[2]));
						break;

					case "Show":
						var details = this.studentData.GetDetails(arguments[0]);
						Console.WriteLine(details);
						break;

					case "Exit":
						Environment.Exit(0);
						break;
				}
			}
		}
	}
}
