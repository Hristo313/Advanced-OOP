using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
	public class Engineer : SpecialisedSoldier, IEngineer
	{
		private readonly ICollection<IRepair> repairs;

		public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
			: base(id, firstName, lastName, salary, corps)
		{
			this.repairs = new List<IRepair>();
		}

		public IReadOnlyCollection<IRepair> Repairs
			=>(IReadOnlyCollection<IRepair>)this.repairs;

		public void AddRepair(IRepair repair)
		{
			this.repairs.Add(repair);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.ToString())
				.AppendLine("Repairs:");

			foreach (var repair in this.repairs)
			{
				sb.AppendLine($"  {repair.ToString()}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
