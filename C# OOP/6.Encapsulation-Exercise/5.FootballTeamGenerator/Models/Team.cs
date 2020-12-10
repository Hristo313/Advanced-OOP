using _5.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator
{
	public class Team
	{
		private readonly List<Player> players;
		private string name;

		private Team()
		{
			this.players = new List<Player>();
		}

		public Team(string name)
			: this()
		{
			this.Name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(GlobalConstants
						.EmptyNameExceptionMessage);
				}

				this.name = value;
			}
		}

		public int Rating
		{
			get
			{
				if(this.players.Count == 0)
				{
					return 0;
				}

				return (int)Math.Round(this.players
					.Sum(p => p.OveralSkill)) /
			         this.players.Count;
			}
		}		

		public void AddPlayer(Player player)
		{
			this.players.Add(player);
		}

		public void RemovePlayer(string name)
		{
			Player playerToRemove = this.players
				.FirstOrDefault(p => p.Name == name);

			if(playerToRemove == null)
			{
				string excMsg = string.Format(GlobalConstants
					.RemovingMissingPlayerExceptionMessage, name, this.Name);
				throw new InvalidOperationException(excMsg);
			}

			this.players.Remove(playerToRemove);
		}

		public override string ToString()
		{
			return $"{this.Name} - {this.Rating}";
		}
	}
}
