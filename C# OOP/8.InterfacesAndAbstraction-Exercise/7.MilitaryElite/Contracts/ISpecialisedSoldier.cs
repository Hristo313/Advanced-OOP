using _7.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
	public interface ISpecialisedSoldier : IPrivate
	{
		Corps Corps { get; }
	}
}
