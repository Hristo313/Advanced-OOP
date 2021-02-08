using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonTrainer
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

			while (true)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string trainerName = line[0];

				if (trainerName == "Tournament")
				{
					break;
				}

				string pokemonName = line[1];
				string pokemonElement = line[2];
				int pokemonHealth = int.Parse(line[3]);

				if (!trainers.ContainsKey(trainerName))
				{
					trainers.Add(trainerName, new Trainer(trainerName));
				}

				Trainer currentTrainer = trainers[trainerName];
				Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
				currentTrainer.Pokemons.Add(pokemon);
			}
			while (true)
			{
				string element = Console.ReadLine();

				if (element == "End")
				{
					break;
				}

				foreach (var trainer in trainers)
				{
					if (trainer.Value.Pokemons.Any(p => p.Element == element))
					{
						trainer.Value.NumberOfBadges++;
					}
					else
					{
						foreach (var pokemon in trainer.Value.Pokemons)
						{
							pokemon.Health -= 10;
						}

						trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
					}
				}
			}

			var result = trainers
				.OrderByDescending(x => x.Value.NumberOfBadges)
				.ToDictionary(k => k.Key, v => v.Value);

			foreach (var item in result)
			{
				string trainerName = item.Key;
				var badges = item.Value;

				Console.WriteLine($"{trainerName} {badges.NumberOfBadges} {item.Value.Pokemons.Count}");
			}
		}
	}
}
