using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace _7.MilitaryElite.Models
{
	public class Commando : SpecialisedSoldier, ICommando
	{
		private readonly ICollection<IMission> missions;

		public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
			: base(id, firstName, lastName, salary, corps)
		{
			this.missions = new List<IMission>();
		}

		public IReadOnlyCollection<IMission> Missions
			=> (IReadOnlyCollection<IMission>)this.missions;

		public void AddMission(IMission mission)
		{
			this.missions.Add(mission);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.ToString())
				.AppendLine("Missions:");

			foreach (var mission in this.missions)
			{
				sb.AppendLine($"  {mission.ToString()}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
