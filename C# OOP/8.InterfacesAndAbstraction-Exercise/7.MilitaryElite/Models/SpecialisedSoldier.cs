using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enumerations;
using _7.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
	public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
	{
		public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
			: base(id, firstName, lastName, salary)
		{
			this.Corps = this.TryParseCorps(corps);
		}

		public Corps Corps { get; private set; }

		private Corps TryParseCorps(string corpsStr)
		{
			bool parsed = Enum.TryParse<Corps>(corpsStr, out Corps corps);

			if(!parsed)
			{
				throw new InvalidCorpsException();
			}

			return corps;
		}

		public override string ToString()
		{
			return base.ToString() + Environment.NewLine +
				$"Corps: {this.Corps.ToString()}";
		}
	}
}
