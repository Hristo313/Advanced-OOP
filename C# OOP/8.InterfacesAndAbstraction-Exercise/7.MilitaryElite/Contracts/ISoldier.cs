using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
	public interface ISoldier
	{
		int Id { get; }

		string FirstName { get; }

		string LastName { get; }
	}
}
