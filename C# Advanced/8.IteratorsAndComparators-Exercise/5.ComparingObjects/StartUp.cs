using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			List<Person> people = new List<Person>();

			while(true)
			{
				string[] personInfo = Console.ReadLine().Split(" ");

				if(personInfo[0] == "END")
				{
					break;
				}

				string name = personInfo[0];
				int age = int.Parse(personInfo[1]);
				string town = personInfo[2];

				Person person = new Person(name, age, town);
				people.Add(person);
			}

			int n = int.Parse(Console.ReadLine());

			int matchesCount = 0;

			Person personToCompare = people[n - 1];

			foreach (var person in people)
			{
				if(personToCompare.CompareTo(person) == 0)
				{
					matchesCount++;
				}
			}

			if(matchesCount <= 1) 
			{
				Console.WriteLine("No matches");
			}
			else
			{
				int notMatchesCount = people.Count - matchesCount;
				Console.WriteLine($"{matchesCount} {notMatchesCount} {people.Count}");
			}
		}
	}
}
