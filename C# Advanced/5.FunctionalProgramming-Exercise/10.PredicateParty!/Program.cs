using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
	class Program
	{
		static void Main(string[] args)
		{
			var guests = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			while(true)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				string command = line[0];

				if(command == "Party!")
				{
					break;
				}

				string[] predicateArgs = line.Skip(1).ToArray();

				Predicate<string> predicate = GetPredicate(predicateArgs);

				if(command == "Remove")
				{
					guests.RemoveAll(predicate);
				}
				else if(command == "Double")
				{
					DoubleGuests(guests, predicate);
				}
			}

			if(!guests.Any())
			{
				Console.WriteLine("Nobody is going to the party!");
			}
			else
			{
				Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
			}
		}

		private static void DoubleGuests(List<string> guests, Predicate<string> predicate)
		{
			for (int i = 0; i < guests.Count; i++)
			{
				string currentGuest = guests[i];

				if (predicate(currentGuest))
				{
					guests.Insert(i + 1, currentGuest);
					i++;
				}
			}
		}

		static Predicate<string> GetPredicate(string[] predicateArgs)
		{
			string type = predicateArgs[0];
			string argument = predicateArgs[1];

			Predicate<string> predicate = null;

			if(type == "StartsWith")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.StartsWith(argument);
				});
			}
			else if(type == "EndsWith")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.EndsWith(argument);
				});
			}
			else if(type == "Length")
			{
				predicate = new Predicate<string>((name) =>
				{
					return name.Length == int.Parse(argument);
				});
			}

			return predicate;
		}
	}
}
