using _5.FootballTeamGenerator.Common;
using _5.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
	public class Player
	{
		private string name;

		public Player(string name, Stats stats)
		{
			this.Name = name;
			this.Stats = stats;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			private set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(GlobalConstants
						.EmptyNameExceptionMessage);
				}

				this.name = value;
			}
		}

		public Stats Stats { get; }

		public double OveralSkill =>
			this.Stats.AverageStats;
	}
}
