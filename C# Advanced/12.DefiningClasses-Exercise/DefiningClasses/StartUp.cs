using System;
using System.Collections.Generic;

namespace DefiningClasses
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Family family = new Family();

			for (int i = 0; i < n; i++)
			{
				string[] personArg = Console.ReadLine().Split();

				string name = personArg[0];
				int age = int.Parse(personArg[1]);

				Person person = new Person(name, age);

				family.AddMember(person);					
			}

			HashSet<Person> result = family.GetAllPeopleAbove30();

			Console.WriteLine(string.Join(Environment.NewLine, result));
		}
	}
}
