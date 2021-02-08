using _9.ExplicitInterfaces.Contracts;
using _9.ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9.ExplicitInterfaces.Core
{
	public class Engine
	{
		public Engine()
		{

		}

		public void Run()
		{
			GetPerson();
		}

		private static void GetPerson()
		{
			while (true)
			{
				string[] info = Console.ReadLine().Split();

				if (info[0] == "End")
				{
					break;
				}

				string name = info[0];
				string country = info[1];
				int age = int.Parse(info[2]);

				Citizen citizen = new Citizen(name, country, age);

				IPerson person = citizen;
				IResident resident = citizen;

				Console.WriteLine(person.GetName());
				Console.WriteLine(resident.GetName());
			}
		}
	}
}
