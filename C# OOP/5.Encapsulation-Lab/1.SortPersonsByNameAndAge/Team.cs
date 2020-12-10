using System;
using System.Collections.Generic;
using System.Text;

namespace _1.SortPersonsByNameAndAge
{
	public class Team
	{
		private readonly List<Person> firstTeam;
		private readonly List<Person> reserveTeam;

		public Team(string name)
		{
			this.Name = name;
			this.firstTeam = new List<Person>();
			this.reserveTeam = new List<Person>();
		}

		public string Name { get; private set; }

		public IReadOnlyCollection<Person> FirstTeam => this.firstTeam;

		public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam;

		public void AddPlayer(Person person)
		{
			if(person.Age < 40)
			{
				firstTeam.Add(person);
			}
			else
			{
				reserveTeam.Add(person);
			}
		}
	}
}
