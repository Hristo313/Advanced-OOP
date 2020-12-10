using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
	class Program
	{
		static void Main(string[] args)
		{
			int totalPeople = int.Parse(Console.ReadLine());

			var people = new List<Person>();

			for (int i = 0; i < totalPeople; i++)
			{
				var currentPerson = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

				var person = new Person
				{
					Name = currentPerson[0],
					Age = int.Parse(currentPerson[1])
				};

				people.Add(person);
			}

			var filter = Console.ReadLine();
			var age = int.Parse(Console.ReadLine());

			Func<Person, bool> filterFunc = filter switch
			{
				"older" => p => p.Age >= age,
				"younger" => p => p.Age <= age
			};

			var outputFormat = Console.ReadLine();

			Func<Person, string> outputFunc = outputFormat switch
			{
				"name age" => p => $"{p.Name} - {p.Age}",
				"name" => p => $"{p.Name}"
			};

			people
				.Where(filterFunc)
				.Select(outputFunc)
				.ToList()
				.ForEach(Console.WriteLine);
		}
	}
}
