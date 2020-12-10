using System;
using System.Collections.Generic;

namespace _07.PredicateForNames
{
	class Program
	{
		static void Main(string[] args)
		{
			int length = int.Parse(Console.ReadLine());

			string[] names = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			List<string> list = new List<string>(names);

			for (int i = 0; i < names.Length; i++)
			{
				string name = names[i];

				Predicate<string> predicate = name.Length <= length ?
					new Predicate<string>(n => 2 > 1) :
					new Predicate<string>(n => 2 > 3);

				if (!predicate(name))
				{
					list.Remove(name);
				}
			}

			foreach (var name in list)
			{
				Console.WriteLine(name);
			}
		}
	}
}
