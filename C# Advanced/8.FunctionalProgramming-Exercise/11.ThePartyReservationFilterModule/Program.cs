using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
	class Program
	{
		static void Main(string[] args)
		{
			Action<List<string>> print = new Action<List<string>>((guest) =>
			{
				Console.WriteLine(string.Join(" ", guest));
			});

			string[] guests = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			List<string> filter = new List<string>(guests);

			while (true)
			{
				string[] line = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
				string command = line[0];

				if (command == "Print")
				{
					print(filter);
					break;
				}

				string[] predicateArgs = line.Skip(1).ToArray();

				Predicate<string> predicate = GetPredicate(predicateArgs);

				if (command == "Add filter")
				{
					filter.RemoveAll(predicate);
				}
				else if (command == "Remove filter")
				{
					string letter = line[2];

					for (int i = 0; i < guests.Length; i++)
					{
						string name = guests[i];

						if (name.StartsWith(letter) || name.EndsWith(letter))
						{
							filter.Add(name);
						}
					}
				}
			}
		}

		static Predicate<string> GetPredicate(string[] predicateArgs)
		{
			string type = predicateArgs[0];
			string argument = predicateArgs[1];

			Predicate<string> predicate = null;

			if (type == "Starts with")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.StartsWith(argument);
				});
			}
			else if (type == "Ends with")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.EndsWith(argument);
				});
			}
			else if (type == "Length")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.Length == int.Parse(argument);
				});
			}
			else if (type == "Contains")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.Contains(argument);
				});
			}

			return predicate;
		}
	}
}
