using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _1.SortPersonsByNameAndAge
{
	public class StartUp
	{
		public static void Main()
		{
			//5
			//Asen Ivanov 20 2200
			//Boiko Borisov 57 3333
			//Ventsislav Ivanov 27 600
			//Grigor Dimitrov 25 666,66
			//Boiko Angelov 35 555

			//Exercise 3
			//try
			//{
			//	var lines = int.Parse(Console.ReadLine());
			//	var persons = new List<Person>();

			//	for (int i = 0; i < lines; i++)
			//	{
			//		var cmdArgs = Console.ReadLine().Split();
			//		var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
			//		persons.Add(person);
			//	}

			//	var parcentage = decimal.Parse(Console.ReadLine());
			//	persons.ForEach(p => p.IncreaseSalary(parcentage));
			//	persons.ForEach(p => Console.WriteLine(p.ToString()));
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}

			var lines = int.Parse(Console.ReadLine());
			var persons = new List<Person>();

			for (int i = 0; i < lines; i++)
			{
				var cmdArgs = Console.ReadLine().Split();
				var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
				persons.Add(person);
			}

			Team team = new Team("SoftUni");

			foreach (Person person in persons)
			{
				team.AddPlayer(person);
			}

			Console.WriteLine( $"First team has {team.FirstTeam.Count} players.");
			Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
		}
	}
}
