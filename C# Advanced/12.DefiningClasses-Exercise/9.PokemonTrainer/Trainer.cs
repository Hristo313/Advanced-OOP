using System;
using System.Collections.Generic;
using System.Text;

namespace _9.PokemonTrainer
{
	public class Trainer
	{
		private string name;
		private int numberOfBadges;
		private List<Pokemon> pokemons;

		public Trainer(string name)
		{
			this.Name = name;
			this.NumberOfBadges = 0;
			this.Pokemons = new List<Pokemon>();
		}

		public string Name { get; set; }

		public int NumberOfBadges { get; set; } = 0;

		public List<Pokemon> Pokemons { get; }

	}
}
