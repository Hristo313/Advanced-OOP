using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
	class Program
	{
		static void Main(string[] args)
		{
			int numberOfContinents = int.Parse(Console.ReadLine());

			var continents = new Dictionary<string, Dictionary<string, List<string>>>();

			for (int i = 0; i < numberOfContinents; i++)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string continent = line[0];
				string country = line[1];
				string town = line[2];

				if (!continents.ContainsKey(continent))
				{
					continents[continent] = new Dictionary<string, List<string>>();
				}

				if (!continents[continent].ContainsKey(country))
				{
					continents[continent][country] = new List<string>();
				}

				continents[continent][country].Add(town);
			}

			foreach (var kvp in continents)
			{
				var continent = kvp.Key;
				var countries = kvp.Value;

				Console.WriteLine($"{continent}:");
				foreach (var kvpCountry in countries)
				{
					var country = kvpCountry.Key;
					var town = kvpCountry.Value;

					Console.WriteLine($"  {country} -> {string.Join(", ", town)}");
				}
			}
		}
	}
}
