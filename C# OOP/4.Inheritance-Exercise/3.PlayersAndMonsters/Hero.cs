using System;
using System.Collections.Generic;
using System.Text;

namespace _3.PlayersAndMonsters
{
	public class Hero
	{
		private const int HERO_MIN_LEVEL = 0;

		private string username;
		private int level;

		public Hero(string username, int level)
		{
			this.Username = username;
			this.Level = level;
		}

		public string Username
		{
			get
			{
				return this.username;
			}
			private set
			{
				if (String.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Username cannot be null or white space");
				}

				this.username = value;
			}
		}
		

		public int Level
		{
			get
			{
				return this.level;
			}
			private set
			{
				if(value < HERO_MIN_LEVEL)
				{
					throw new AggregateException("Level cannot be less than zero");
				}

				this.level = value;
			}
		}


		public override string ToString()
		{
			return $"Type: { this.GetType().Name} Username: { this.Username}bLevel: { this.Level}";
		}
	}
}
